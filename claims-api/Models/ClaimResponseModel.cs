using ClaimsApi.Data.DTO;

namespace ClaimsApi.Models
{
	/// <summary>
	/// Strongly typed response model for claims
	/// </summary>
	public class ClaimResponseModel :
		AbstractResponseModel<ClaimDto>
	{
		public ClaimResponseModel(ClaimDto data) :
			base(data)
		{
		}
	}
}