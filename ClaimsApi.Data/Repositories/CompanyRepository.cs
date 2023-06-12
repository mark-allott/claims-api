using ClaimsApi.Data.Context;
using ClaimsApi.Data.Entities;
using ClaimsApi.Data.Interfaces.Repositories;

namespace ClaimsApi.Data.Repositories
{
	public class CompanyRepository :
		AbstractRepository<ClaimContext, Company>,
		ICompanyRepository
	{
		public CompanyRepository(ClaimContext context) :
			base(context)
		{
		}
	}
}