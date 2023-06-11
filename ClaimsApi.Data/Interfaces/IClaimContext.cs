using ClaimsApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClaimsApi.Data.Interfaces
{
	/// <summary>
	/// Defines the entities expected in the claims database
	/// </summary>
	public interface IClaimContext
	{
		/// <summary>
		/// The individual claims
		/// </summary>
		public DbSet<Claim>? Claims { get; set; }

		/// <summary>
		/// The types fo claim that can be made
		/// </summary>
		public DbSet<ClaimType>? ClaimTypes { get; set; }

		/// <summary>
		/// A list of companies with insurance
		/// </summary>
		public DbSet<Company>? Companies { get; set; }
	}
}