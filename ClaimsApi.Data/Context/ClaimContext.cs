using ClaimsApi.Data.Entities;
using ClaimsApi.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClaimsApi.Data.Context
{
	public class ClaimContext :
		DbContext,
		IClaimContext
	{
		#region Ctor

		public ClaimContext(DbContextOptions<ClaimContext> options) :
			base(options)
		{
		}

		#endregion Ctor

		#region overrides

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Claim>()
				.HasNoKey();

			modelBuilder.Entity<ClaimType>()
				.HasNoKey();
		}

		#endregion overrides

		#region IClaimContext implementation

		/// <inheritdoc />
		public DbSet<Claim>? Claims { get; set; }

		/// <inheritdoc />
		public DbSet<ClaimType>? ClaimTypes { get; set; }

		/// <inheritdoc />
		public DbSet<Company>? Companies { get; set; }

		#endregion IClaimContext implementation
	}
}