using System;
using ClaimsApi.Data.DTO;
using ClaimsApi.Data.Entities;

namespace ClaimsApi.Data.Interfaces.Services
{
	public interface IClaimService :
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

		/// <summary>
		/// Updates a claim with the specified fields
		/// </summary>
		/// <param name="ucr"></param>
		/// <param name="claimDate"></param>
		/// <param name="lossDate"></param>
		/// <param name="assuredName"></param>
		/// <param name="incurredLoss"></param>
		/// <param name="closed"></param>
		/// <returns>A flag indicating success or failure</returns>
		bool UpdateClaim(string ucr, DateTime? claimDate, DateTime? lossDate, string? assuredName, decimal? incurredLoss,
			bool closed);

#if DEBUG

		/// <summary>
		/// For DEBUG only - we can create a dummy entry
		/// </summary>
		/// <param name="ucr">The UCR to us for the dummy entry</param>
		/// <returns>A <see cref="ClaimDto"/> model, but backed with an entity in the DB</returns>
		ClaimDto CreateTestClaim(string ucr);

#endif
	}
}