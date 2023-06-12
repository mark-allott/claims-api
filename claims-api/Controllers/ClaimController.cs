using System.Text.Json;
using System.Text.RegularExpressions;
using ClaimsApi.Data.Interfaces.Services;
using ClaimsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsApi.Controllers
{
	public class ClaimController :
		AbstractApiController
	{
		#region Ctor

		private readonly IClaimService _claimService;
		private readonly Regex _ucrPattern = new Regex("^\\w{3}-\\d{8}", RegexOptions.Compiled | RegexOptions.IgnoreCase);

		public ClaimController(ILoggerFactory loggerFactory, IClaimService claimService) :
			base(loggerFactory)
		{
			_claimService = claimService;
		}

		#endregion Ctor

		[HttpGet]
		[Route("{ucr:required}")]
		[ProducesDefaultResponseType(typeof(ClaimResponseModel))]
		public IActionResult GetClaim([FromRoute] string ucr)
		{
			try
			{
				var claim = _claimService.GetClaim(ucr);

#if DEBUG
				if (claim is null && _ucrPattern.IsMatch(ucr.Trim()))
					claim = _claimService.CreateTestClaim(ucr);
#endif
				var isSuccessful = claim is not null;

				var result = new ClaimResponseModel(claim)
				{
					Success = isSuccessful,
					Message = isSuccessful
						? "Success"
						: $"No result for {ucr}"
				};

				return new JsonResult(result);
			}
			catch (Exception e)
			{
				Logger.LogError(e, $"Error when executing {nameof(GetClaim)} with {nameof(ucr)}='{ucr}'");
			}

			return BadRequest();
		}

		[HttpPost]
		[Route("update")]
		[ProducesDefaultResponseType(typeof(ClaimResponseModel))]
		public IActionResult UpdateClaim([FromBody] ClaimUpdateRequestModel claim)
		{
			try
			{
				var updateResult = _claimService.UpdateClaim(claim.Ucr, claim.ClaimDate, claim.LossDate, claim.AssuredName,
					claim.IncurredLoss, claim.Closed);

				var result = new ClaimResponseModel(null)
				{
					Success = updateResult,
					Message = updateResult
						? "Success"
						: "Could not update claim"
				};

				return new JsonResult(result);
			}
			catch (Exception e)
			{
				Logger.LogError(e, $"Error when executing {nameof(UpdateClaim)} with payload: {JsonSerializer.Serialize(claim)}");
				return new JsonResult(new ClaimResponseModel(null) { Success = false, Message = e.Message });
			}
		}
	}
}