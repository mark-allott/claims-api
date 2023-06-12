using ClaimsApi.Data.Context;
using ClaimsApi.Data.Entities;
using ClaimsApi.Data.Interfaces.Repositories;

namespace ClaimsApi.Data.Repositories
{
	public class CompanyCommandRepository :
		AbstractCommandRepository<ClaimContext, Company>,
		ICompanyCommandRepository

	{
		public CompanyCommandRepository(ClaimContext context) :
			base(context)
		{
		}
	}
}