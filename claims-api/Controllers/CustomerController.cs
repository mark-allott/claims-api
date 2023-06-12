using Microsoft.AspNetCore.Mvc;

namespace ClaimsApi.Controllers
{
	public class CustomerController :
		AbstractApiController
	{
		public CustomerController(ILoggerFactory loggerFactory) :
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