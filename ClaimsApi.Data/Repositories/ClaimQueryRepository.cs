using ClaimsApi.Data.Context;
using ClaimsApi.Data.Entities;
using ClaimsApi.Data.Interfaces.Repositories;

namespace ClaimsApi.Data.Repositories
{
	public class ClaimQueryRepository :
		AbstractQueryRepository<ClaimContext, Claim>,
		IClaimQueryRepository
	{
		public ClaimQueryRepository(ClaimContext context) :
			base(context)
		{
		}
	}
}