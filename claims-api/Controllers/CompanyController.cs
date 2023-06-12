using ClaimsApi.Data.Interfaces.Services;
using ClaimsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsApi.Controllers
{
	public class CompanyController :
		AbstractApiController
	{
		private readonly ICompanyService _companyService;

		public CompanyController(ILoggerFactory loggerFactory, ICompanyService companyService) :
			base(loggerFactory)
		{
			_companyService = companyService;
		}

		[HttpGet]
		[Route("{id:int}")]
		[ProducesDefaultResponseType(typeof(CompanyResponseModel))]
		public IActionResult GetCustomer([FromRoute] int id)
		{
			try
			{
				var company = _companyService.GetCompany(id);
				var isSuccessful = company is not null;

				var result = new CompanyResponseModel(company)
				{
					Success = isSuccessful,
					Message = isSuccessful
						? "Success"
						: $"No result for {id}"
				};

				return new JsonResult(result);
			}
			catch (Exception e)
			{
				Logger.LogError(e, $"Error when executing {nameof(GetCustomer)} with {nameof(id)}='{id}'");
			}

			return BadRequest();
		}

		[HttpGet]
		[Route("{id:int}/claims")]
		[ProducesDefaultResponseType(typeof(CompanyResponseModel))]
		public IActionResult GetCustomerClaims([FromRoute] int id)
		{
			try
			{
				var company = _companyService.GetCompanyClaims(id);
				var isSuccessful = company is not null;

				var result = new CompanyResponseModel(company)
				{
					Success = isSuccessful,
					Message = isSuccessful
						? "Success"
						: $"No result for {id}"
				};

				return new JsonResult(result);
			}
			catch (Exception e)
			{
				Logger.LogError(e, $"Error when executing {nameof(GetCustomer)} with {nameof(id)}='{id}'");
			}

			return BadRequest();
		}
	}
}