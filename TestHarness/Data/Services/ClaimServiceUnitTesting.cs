using ClaimsApi.Data.Context;
using ClaimsApi.Data.Entities;
using ClaimsApi.Data.Interfaces;
using ClaimsApi.Data.Interfaces.Repositories;
using ClaimsApi.Data.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace TestHarness.Data.Services;

[TestClass]
public class ClaimServiceUnitTesting
{
	private Mock<ILogger<ClaimService>> MockLogger
	{
		get { return new Mock<ILogger<ClaimService>>(); }
	}

	private Mock<IClaimRepository> MockClaimRepository
	{
		get { return new Mock<IClaimRepository>(); }
	}

	private Mock<IUnitOfWork<ClaimContext>> MockUnitOfWork
	{
		get { return new Mock<IUnitOfWork<ClaimContext>>(); }
	}

	private Mock<ICompanyRepository> MockCompanyRepository
	{
		get { return new Mock<ICompanyRepository>(); }
	}

	[TestMethod]
	public void ClaimService_GetClaim_ForBlankUcr_ReturnsNull()
	{
		//	setup
		var mockLogger = MockLogger.Object;
		var mockClaimRepo = MockClaimRepository.Object;
		var mockUnitOfWork = MockUnitOfWork.Object;
		var mockCompanyRepo = MockCompanyRepository.Object;

		var claimService = new ClaimService(mockLogger, mockClaimRepo, mockUnitOfWork, mockCompanyRepo);

		var result = claimService.GetClaim(string.Empty);

		result.Should().BeNull();
	}

	[TestMethod]
	public void ClaimService_GetClaim_ForWhiteSpaceUcr_ReturnsNull()
	{
		//	setup
		var mockLogger = MockLogger.Object;
		var mockClaimRepo = MockClaimRepository.Object;
		var mockUnitOfWork = MockUnitOfWork.Object;
		var mockCompanyRepo = MockCompanyRepository.Object;

		var claimService = new ClaimService(mockLogger, mockClaimRepo, mockUnitOfWork, mockCompanyRepo);

		var result = claimService.GetClaim(new string(' ', 5));

		result.Should().BeNull();
	}

	[TestMethod]
	public void ClaimService_GetClaim_ReturnsValidClaim()
	{
		//	setup
		var mockLogger = MockLogger.Object;

		var rng = new Random();

		var claims = new List<Claim>()
		{
			//	Unassociated to company
			new Claim
			{
				Ucr = "ABC-12345678",
				CompanyId = null,
				ClaimDate = DateTime.Today.AddDays(rng.Next(-60, -10)),
				LossDate = null,
				AssuredName = "The assured",
				IncurredLoss = null,
				Closed = false,
				Identity = 1,
				Company = null
			},
			new Claim
			{
				Ucr = "BCD-12345678",
				CompanyId = null,
				ClaimDate = DateTime.Today.AddDays(rng.Next(-60, -10)),
				LossDate = null,
				AssuredName = "The assured",
				IncurredLoss = null,
				Closed = false,
				Identity = 2,
				Company = null
			}
		};

		var mockClaims = MockClaimRepository;
		mockClaims.Setup(m => m.Queryable)
			.Returns(claims.AsQueryable());
		mockClaims.Setup(m => m.UntrackedQueryable)
			.Returns(claims.AsQueryable().AsNoTracking());

		var mockClaimRepo = mockClaims.Object;
		var mockUnitOfWork = MockUnitOfWork.Object;
		var mockCompanyRepo = MockCompanyRepository.Object;

		var claimService = new ClaimService(mockLogger, mockClaimRepo, mockUnitOfWork, mockCompanyRepo);

		var result = claimService.GetClaim("ABC-12345678");

		result.Should().NotBeNull();
		result?.Ucr.Should().Be("ABC-12345678");
	}

	[TestMethod]
	public void ClaimService_UpdateClaim_Fails_ForNoClaimDateSupplied()
	{
		//	setup
		var mockLogger = MockLogger.Object;

		var rng = new Random();

		var claims = new List<Claim>()
		{
			//	Unassociated to company
			new Claim
			{
				Ucr = "CDE-12345678",
				CompanyId = null,
				ClaimDate = DateTime.Today.AddDays(rng.Next(-60, -10)),
				LossDate = null,
				AssuredName = "The assured",
				IncurredLoss = null,
				Closed = false,
				Identity = 1,
				Company = null
			},
			new Claim
			{
				Ucr = "DEF-12345678",
				CompanyId = null,
				ClaimDate = DateTime.Today.AddDays(rng.Next(-60, -10)),
				LossDate = null,
				AssuredName = "The assured",
				IncurredLoss = null,
				Closed = false,
				Identity = 2,
				Company = null
			}
		};

		var mockClaims = MockClaimRepository;
		mockClaims.Setup(m => m.Queryable)
			.Returns(claims.AsQueryable());
		mockClaims.Setup(m => m.UntrackedQueryable)
			.Returns(claims.AsQueryable().AsNoTracking());

		var mockClaimRepo = mockClaims.Object;
		var mockUnitOfWork = MockUnitOfWork.Object;
		var mockCompanyRepo = MockCompanyRepository.Object;

		var claimService = new ClaimService(mockLogger, mockClaimRepo, mockUnitOfWork, mockCompanyRepo);

		//	Grab the first entry to update
		var claimToUpdate = mockClaimRepo.Queryable.FirstOrDefault();
		claimToUpdate.Should().NotBeNull();

		Assert.ThrowsException<ArgumentException>(() => claimService.UpdateClaim(claimToUpdate.Ucr, null, null, null, null, false));
	}

	[TestMethod]
	public void ClaimService_UpdateClaim_Fails_ForDifferentClaimDateSupplied()
	{
		//	setup
		var mockLogger = MockLogger.Object;

		var rng = new Random();

		var claims = new List<Claim>()
		{
			//	Unassociated to company
			new Claim
			{
				Ucr = "EFG-12345678",
				CompanyId = null,
				ClaimDate = DateTime.Today.AddDays(rng.Next(-60, -10)),
				LossDate = null,
				AssuredName = "The assured",
				IncurredLoss = null,
				Closed = false,
				Identity = 1,
				Company = null
			},
			new Claim
			{
				Ucr = "FGH-12345678",
				CompanyId = null,
				ClaimDate = DateTime.Today.AddDays(rng.Next(-60, -10)),
				LossDate = null,
				AssuredName = "The assured",
				IncurredLoss = null,
				Closed = false,
				Identity = 2,
				Company = null
			}
		};

		var mockClaims = MockClaimRepository;
		mockClaims.Setup(m => m.Queryable)
			.Returns(claims.AsQueryable());
		mockClaims.Setup(m => m.UntrackedQueryable)
			.Returns(claims.AsQueryable().AsNoTracking());

		var mockClaimRepo = mockClaims.Object;
		var mockUnitOfWork = MockUnitOfWork.Object;
		var mockCompanyRepo = MockCompanyRepository.Object;

		var claimService = new ClaimService(mockLogger, mockClaimRepo, mockUnitOfWork, mockCompanyRepo);

		//	Grab the first entry to update
		var claimToUpdate = mockClaimRepo.Queryable.FirstOrDefault();
		claimToUpdate.Should().NotBeNull();

		Assert.ThrowsException<InvalidOperationException>(() => claimService.UpdateClaim(claimToUpdate.Ucr, claimToUpdate.ClaimDate.Value.AddDays(1), null, null, null, false));
	}
}