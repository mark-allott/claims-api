using Microsoft.AspNetCore.Mvc;

namespace ClaimsApi.Controllers
{
	public class CompanyController :
		AbstractApiController
	{
		public CompanyController(ILoggerFactory loggerFactory) :
			base(loggerFactory)
		{
		}

		[HttpGet]
		[Route("{id:int}")]
		public IActionResult GetCustomer([FromRoute] int id)
		{
			return BadRequest();
		}
	}
}