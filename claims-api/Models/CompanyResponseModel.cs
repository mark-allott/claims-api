using ClaimsApi.Data.DTO;

namespace ClaimsApi.Models
{
	/// <summary>
	/// Strongly-typed response model for Company operations
	/// </summary>
	public class CompanyResponseModel :
		AbstractResponseModel<CompanyDto>
	{
		public CompanyResponseModel(CompanyDto data) :
			base(data)
		{
		}
	}
}