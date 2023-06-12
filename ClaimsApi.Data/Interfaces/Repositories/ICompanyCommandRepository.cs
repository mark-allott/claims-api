using ClaimsApi.Data.Entities;

namespace ClaimsApi.Data.Interfaces.Repositories
{
	/// <summary>
	/// Strongly-typed version of the command repository for accessing Company data
	/// </summary>
	public interface ICompanyCommandRepository :
		ICommandRepository<Company>
	{
	}
}