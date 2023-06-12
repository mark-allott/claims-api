using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClaimsApi.Data.Entities
{
	/// <summary>
	/// Definition for the Claims table, based on the following DDL:
	/// <code>
	/// CREATE TABLE Claims
	/// (
	/// UCR VARCHAR(20),
	/// CompanyId INT,
	/// ClaimDate DATETIME,
	/// LossDate DATETIME,
	/// [Assured Name] VARCHAR(100),
	/// [Incurred Loss] DECIMAL(15,2),
	/// Closed BIT
	/// )
	/// </code>
	/// </summary>
	[Index(nameof(Claim.Ucr), IsUnique = true)]
	[PrimaryKey(nameof(Claim.Identity))]
	public class Claim
	{
		/// <summary>
		/// Unique Claim Reference
		/// </summary>
		[Column("UCR", TypeName = "VARCHAR")]
		[StringLength(20)]
		public string? Ucr { get; set; }

		/// <summary>
		/// The ID of the company creating the claim
		/// </summary>
		public int? CompanyId { get; set; }

		/// <summary>
		/// The date of the claim
		/// </summary>
		[Column(TypeName = "DATETIME")]
		public DateTime? ClaimDate { get; set; }

		/// <summary>
		/// The date of the loss
		/// </summary>
		[Column(TypeName = "DATETIME")]
		public DateTime? LossDate { get; set; }

		/// <summary>
		/// The name of the assured
		/// </summary>
		[Column("Assured Name", TypeName = "VARCHAR")]
		[StringLength(100)]
		public string? AssuredName { get; set; }

		/// <summary>
		/// The amount of the loss
		/// </summary>
		[Column("Incurred Loss", TypeName = "DECIMAL(15,2)")]
		public decimal? IncurredLoss { get; set; }

		/// <summary>
		/// Indicator for whether the claim is closed
		/// </summary>
		public bool? Closed { get; set; }

		#region DB Rework

		/// <summary>
		/// Provide a PK for EF to work with FKs
		/// </summary>
		[Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Identity { get; set; }

		#region Navigation properties

		[ForeignKey(nameof(CompanyId))]
		public virtual Company? Company { get; set; }

		#endregion Navigation properties

		#endregion DB Rework
	}
}