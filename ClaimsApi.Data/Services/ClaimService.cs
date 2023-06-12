using ClaimsApi.Data.Context;
using ClaimsApi.Data.DTO;
using ClaimsApi.Data.Entities;
using ClaimsApi.Data.Interfaces;
using ClaimsApi.Data.Interfaces.Repositories;
using ClaimsApi.Data.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Claim = ClaimsApi.Data.Entities.Claim;

namespace ClaimsApi.Data.Services;

public class ClaimService :
	IClaimService
{
	private readonly ILogger<ClaimService> _logger;
	private readonly IClaimRepository _claimRepository;
	private readonly IUnitOfWork<ClaimContext> _uow;
	private readonly ICompanyRepository _companyRepository;

	#region Ctor

	public ClaimService(ILogger<ClaimService> logger, IClaimRepository claimRepository, IUnitOfWork<ClaimContext> uow, ICompanyRepository companyRepository)
	{
		_logger = logger;
		_claimRepository = claimRepository;
		_uow = uow;
		_companyRepository = companyRepository;
	}

	#endregion Ctor

	#region IClaimService implementation

	/// <inheritdoc />
	public ClaimDto? GetClaim(string ucr)
	{
		//	Blank input -> nothing found
		if (string.IsNullOrWhiteSpace(ucr))
			return null;

		try
		{
			//	Convert to lower to perform checks
			var test = ucr.Trim().ToLower();

			//	Find a single matching entry - no need to track as we convert to DTO for the result
			var result = _claimRepository.UntrackedQueryable
				.Include(i => i.Company)
				.SingleOrDefault(q => !string.IsNullOrWhiteSpace(q.Ucr) && q.Ucr.ToLower().Contains(test));

			return result is null
				? null
				: new ClaimDto(result);
		}
		catch (InvalidOperationException ioe)
		{
			//	This should never happen as there's meant to be a unique constraint on the UCR
			_logger.LogError(ioe, $"Multiple matches for UCR: {ucr}");
			return null;
		}
	}

	public bool UpdateClaim(ClaimDto claim)
	{
		var current = GetClaimFromRepository(claim.Ucr);

		//	Not found, so attempt fails
		if (current is null)
			return false;

		//	Perform some sanity checks before any updating takes place
		current = ValidateChanges(current, claim.ClaimDate, claim.LossDate, claim.AssuredName, claim.IncurredLoss,
			claim.Closed);

		//	Update the entry & save
		_claimRepository.Update(current);
		return _uow.SaveChanges() > 0;
	}

	public bool UpdateClaim(string ucr, DateTime? claimDate, DateTime? lossDate, string? assuredName, decimal? incurredLoss,
		bool closed)
	{
		var current = GetClaimFromRepository(ucr);

		//	Not found, so attempt fails
		if (current is null)
			return false;

		//	Perform some sanity checks before any updating takes place
		current = ValidateChanges(current, claimDate, lossDate, assuredName, incurredLoss, closed);

		//	Update the entry & save
		_claimRepository.Update(current);
		return _uow.SaveChanges() > 0;
	}

#if DEBUG

	public ClaimDto CreateTestClaim(string ucr)
	{
		var rng = new Random();

		//	Convert to upper for storage
		var test = ucr.Trim().ToUpper();

		var claimCompany = GetCompany();

		var newClaim = new Claim
		{
			Ucr = test,
			ClaimDate = DateTime.Today.AddDays(-rng.Next(7, 360)),
			LossDate = null,
			AssuredName = "Insured Person",
			IncurredLoss = null,
			Closed = null,
			Company = claimCompany
		};
		_claimRepository.Add(newClaim);
		_uow.SaveChanges();

		return new ClaimDto(newClaim);
	}

	private Company GetCompany()
	{
		var rng = new Random();

		//	If less than 5 companies add one to the repo so wwe can use it
		var companyCount = _companyRepository.UntrackedQueryable.Count();

		if (companyCount < 5)
		{
			var nextId = companyCount + 1;
			var newCompany = new Company
			{
				Id = nextId,
				Name = $"Company #{nextId}",
				Address1 = $"{nextId}, The Road",
				Address2 = "Town",
				Address3 = "City",
				PostCode = "AA1A 1AA",
				Country = "United Kingdom",
				Active = true,
				InsuranceEndDate = DateTime.Today.AddDays(rng.Next(7, 360)),
			};
			_companyRepository.Add(newCompany);
			_uow.SaveChanges();
		}
		companyCount = _companyRepository.UntrackedQueryable.Count();
		var companyId = rng.Next(1, companyCount + 1);

		return _companyRepository.Queryable.Single(q => q.Id == companyId);
	}

#endif

	#endregion IClaimService implementation

	/// <summary>
	/// Locates a claim from the repo based on <paramref name="ucr"/>
	/// </summary>
	/// <param name="ucr">The reference used to locate an entity</param>
	/// <returns>The located entity, or null</returns>
	private Claim? GetClaimFromRepository(string ucr)
	{
		//	Convert to lower to perform checks
		var test = ucr.Trim().ToLower();

		//	If the UCR is null/blank, cannot update
		if (string.IsNullOrWhiteSpace(test))
			return null;

		//	We care about EF tracking here, so use Queryable with tracking
		return _claimRepository.Queryable
			.Include(i => i.Company)
			.SingleOrDefault(q => !string.IsNullOrWhiteSpace(q.Ucr) && q.Ucr.ToLower().Contains(test));
	}

	/// <summary>
	/// Performs sanity checks on incoming values
	/// </summary>
	/// <param name="current">An existing entity</param>
	/// <param name="claimDate">The proposed claim date</param>
	/// <param name="lossDate">The proposed loss date</param>
	/// <param name="assuredName">The proposed name</param>
	/// <param name="incurredLoss">The proposed loss</param>
	/// <param name="closed">The proposed closure flag</param>
	/// <returns>An updated entity</returns>
	/// <exception cref="ArgumentNullException"></exception>
	private Claim ValidateChanges(Claim current, DateTime? claimDate, DateTime? lossDate, string? assuredName,
		decimal? incurredLoss, bool closed)
	{
		_ = current ?? throw new ArgumentNullException(nameof(current));

		//	Must have a claim date set
		if (!claimDate.HasValue)
			throw new ArgumentException($"Must supply a value for claim", nameof(claimDate));

		//	Cannot change claim date if already set
		if (current.ClaimDate.HasValue && current.ClaimDate != claimDate)
			throw new InvalidOperationException($"Attempt to change {nameof(Claim.ClaimDate)}");

		//	Cannot place a claim in the future
		if (claimDate > DateTime.Now)
			throw new ArgumentOutOfRangeException(nameof(ClaimDto.ClaimDate), $"{nameof(ClaimDto.ClaimDate)} cannot be in the future");

		//	TODO - perform a decent range check on claim date to ensure it is within a valid range
		if (claimDate < new DateTime(2000, 1, 1))
			throw new ArgumentOutOfRangeException(nameof(claimDate), $"{nameof(claimDate)} value is out of range");

		if (current.LossDate.HasValue && current.LossDate != lossDate)
			throw new InvalidOperationException($"Attempt to change {nameof(Claim.LossDate)}");

		//	TODO - perform a decent range check on claim date to ensure it is within a valid range
		if (lossDate < new DateTime(2000, 1, 1) || lossDate < claimDate)
			throw new ArgumentOutOfRangeException(nameof(claimDate), $"{nameof(lossDate)} value is out of range");

		//	Set updated values as all checks are now passed
		current.ClaimDate = claimDate;
		current.LossDate = lossDate;
		current.AssuredName = assuredName;
		current.IncurredLoss = incurredLoss;
		current.Closed = closed;

		return current;
	}
}