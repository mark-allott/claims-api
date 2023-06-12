using ClaimsApi.Data.Entities;

namespace ClaimsApi.Data.Interfaces.Repositories
{
	/// <summary>
	/// Strongly-typed version of the query repository to access Company information
	/// </summary>
	public interface ICompanyQueryRepository :
		IQueryRepository<Company>
	{
	}
}