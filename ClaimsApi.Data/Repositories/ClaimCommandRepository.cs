using ClaimsApi.Data.Context;
using ClaimsApi.Data.Entities;
using ClaimsApi.Data.Interfaces.Repositories;

namespace ClaimsApi.Data.Repositories
{
	public class ClaimCommandRepository :
		AbstractCommandRepository<ClaimContext, Claim>,
		IClaimCommandRepository

	{
		public ClaimCommandRepository(ClaimContext context) :
			base(context)
		{
		}
	}
}