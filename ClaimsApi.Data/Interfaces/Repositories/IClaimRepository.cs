using ClaimsApi.Data.Entities;

namespace ClaimsApi.Data.Interfaces.Repositories
{
	/// <summary>
	/// Strongly-typed version of the repository
	/// </summary>
	public interface IClaimRepository :
		IRepository<Claim>,
		IClaimCommandRepository,
		IClaimQueryRepository
	{
	}
}