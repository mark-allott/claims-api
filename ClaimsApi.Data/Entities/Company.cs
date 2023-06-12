using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClaimsApi.Data.Entities
{
	/// <summary>
	/// Definition for the Company table, based on the following DDL:
	/// <code>
	/// CREATE TABLE Company
	/// (
	/// Id INT,
	/// Name VARCHAR(200),
	/// Address1 VARCHAR(100),
	/// Address2 VARCHAR(100),
	/// Address3 VARCHAR(100),
	/// Postcode VARCHAR(20),
	/// Country VARCHAR(50),
	/// Active BIT,
	/// InsuranceEndDate DATETIME
	/// )
	/// </code>
	/// </summary>
	[Table(nameof(Company))]
	[PrimaryKey(nameof(Company.Identity))]
	public class Company
	{
		/// <summary>
		/// The ID for the company
		/// </summary>
		public int? Id { get; set; }

		/// <summary>
		/// The name of the company
		/// </summary>
		[Column(TypeName = "VARCHAR")]
		[StringLength(200)]
		public string? Name { get; set; }

		[Column(TypeName = "VARCHAR")]
		[StringLength(100)]
		public string? Address1 { get; set; }

		[Column(TypeName = "VARCHAR")]
		[StringLength(100)]
		public string? Address2 { get; set; }

		[Column(TypeName = "VARCHAR")]
		[StringLength(100)]
		public string? Address3 { get; set; }

		[Column(TypeName = "VARCHAR")]
		[StringLength(20)]
		public string? PostCode { get; set; }

		[Column(TypeName = "VARCHAR")]
		[StringLength(50)]
		public string? Country { get; set; }

		public bool? Active { get; set; }

		[Column(TypeName = "DATETIME")]
		public DateTime? InsuranceEndDate { get; set; }

		#region DB Rework

		[Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Identity { get; set; }

		#endregion DB Rework
	}
}