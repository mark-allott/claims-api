using ClaimsApi.Data.Entities;

namespace ClaimsApi.Data.Interfaces.Repositories
{
	/// <summary>
	/// Strongly-typed version of the repository
	/// </summary>
	public interface ICompanyRepository :
		IRepository<Company>,
		ICompanyCommandRepository,
		ICompanyQueryRepository
	{
	}
}