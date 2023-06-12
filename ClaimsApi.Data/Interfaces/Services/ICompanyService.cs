using ClaimsApi.Data.DTO;
using ClaimsApi.Data.Entities;

namespace ClaimsApi.Data.Interfaces.Services
{
	public interface ICompanyService :
		IAutoRegisterService
	{
		/// <summary>
		/// Performs a search for a company with the specified <paramref name="id"/>
		/// </summary>
		/// <param name="id">The id to search for (refers to the <see cref="Company.Id"/> column, not its PK identity)</param>
		/// <returns>Details of the company, without any details of claims</returns>
		CompanyDto? GetCompany(int id);

		/// <summary>
		/// Performs a search for a company with the specified <paramref name="id"/>
		/// </summary>
		/// <param name="id">The id to search for (refers to the <see cref="Company.Id"/> column, not its PK identity)</param>
		/// <returns>Details of the company, with details of claims submitted</returns>
		CompanyDto? GetCompanyClaims(int id);
	}
}