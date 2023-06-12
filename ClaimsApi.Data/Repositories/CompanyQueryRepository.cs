using ClaimsApi.Data.Context;
using ClaimsApi.Data.Entities;
using ClaimsApi.Data.Interfaces.Repositories;

namespace ClaimsApi.Data.Repositories
{
	public class CompanyQueryRepository :
		AbstractQueryRepository<ClaimContext, Company>,
		ICompanyQueryRepository
	{
		public CompanyQueryRepository(ClaimContext context) :
			base(context)
		{
		}
	}
}