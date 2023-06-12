using System;
using ClaimsApi.Data.DTO;
using ClaimsApi.Data.Entities;

namespace ClaimsApi.Data.Interfaces.Services
{
	internal interface IClaimService :
		IAutoRegisterService
	{
		/// <summary>
		/// Performs a search for a claim with the <see cref="Claim.Ucr"/> value matching <paramref name="ucr"/>
		/// </summary>
		/// <param name="ucr">The claim relating to <paramref name="ucr"/></param>
		/// <returns>A claim object, if found, or null</returns>
		ClaimDto? GetClaim(string ucr);

		/// <summary>
		/// Attempts to update the claim with the information supplied in <paramref name="claim"/>
		/// </summary>
		/// <param name="claim">Details of the claim to be updated</param>
		/// <returns>A flag indicating success or failure</returns>
		bool UpdateClaim(ClaimDto claim);
	}
}