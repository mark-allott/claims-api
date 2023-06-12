using ClaimsApi.Data.Context;
using ClaimsApi.Data.Entities;
using ClaimsApi.Data.Interfaces.Repositories;

namespace ClaimsApi.Data.Repositories
{
	public class ClaimRepository :
		AbstractRepository<ClaimContext, Claim>,
		IClaimRepository
	{
		public ClaimRepository(ClaimContext context) :
			base(context)
		{
		}
	}
}