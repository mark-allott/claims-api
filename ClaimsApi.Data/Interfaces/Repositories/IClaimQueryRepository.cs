using ClaimsApi.Data.Entities;

namespace ClaimsApi.Data.Interfaces.Repositories
{
	/// <summary>
	/// Strongly-typed version of the query repository to access claim information
	/// </summary>
	public interface IClaimQueryRepository :
		IQueryRepository<Claim>
	{
	}
}