using ClaimsApi.Data.Entities;

namespace ClaimsApi.Data.Interfaces.Repositories
{
	/// <summary>
	/// Strongly-typed version of the command repository for accessing claim data
	/// </summary>
	public interface IClaimCommandRepository :
		ICommandRepository<Claim>
	{
	}
}