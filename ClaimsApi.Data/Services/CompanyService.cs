using ClaimsApi.Data.Context;
using ClaimsApi.Data.DTO;
using ClaimsApi.Data.Interfaces;
using ClaimsApi.Data.Interfaces.Repositories;
using ClaimsApi.Data.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClaimsApi.Data.Services
{
	public class CompanyService :
		ICompanyService
	{
		private readonly ILogger<CompanyService> _logger;
		private readonly ICompanyRepository _companyRepository;
		private readonly IUnitOfWork<ClaimContext> _uow;

		#region Ctor

		public CompanyService(ILogger<CompanyService> logger, ICompanyRepository companyRepository, IUnitOfWork<ClaimContext> uow)
		{
			_logger = logger;
			_companyRepository = companyRepository;
			_uow = uow;
		}

		#endregion Ctor

		/// <inheritdoc />
		public CompanyDto? GetCompany(int id)
		{
			try
			{
				//	Find a single matching entry - no need to track as we convert to DTO for the result
				var result = _companyRepository.UntrackedQueryable
					.SingleOrDefault(q => q.Id == id);

				return result is null
					? null
					: new CompanyDto(result, false);
			}
			catch (Exception e)
			{
				_logger.LogError(e, $"Cannot locate ID: {id}");
				return null;
			}
		}

		/// <inheritdoc />
		public CompanyDto? GetCompanyClaims(int id)
		{
			try
			{
				//	Find a single matching entry - no need to track as we convert to DTO for the result
				var result = _companyRepository.UntrackedQueryable
					.Include(i => i.Claims)
					.SingleOrDefault(q => q.Id == id);

				return result is null
					? null
					: new CompanyDto(result, true);
			}
			catch (Exception e)
			{
				_logger.LogError(e, $"Cannot locate ID: {id}");
				return null;
			}
		}
	}
}