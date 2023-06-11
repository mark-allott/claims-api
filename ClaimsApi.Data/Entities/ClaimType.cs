using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaimsApi.Data.Entities
{
	/// <summary>
	/// Definition for the ClaimType table, based on the following DDL:
	/// <code>
	/// CREATE TABLE ClaimType
	/// (
	/// Id INT,
	/// Name VARCHAR(20)
	/// )
	/// </code>
	/// </summary>
	[Table(nameof(ClaimType))]
	public class ClaimType
	{
		/// <summary>
		/// The ID for the claim type
		/// </summary>
		public int? Id { get; set; }

		/// <summary>
		/// The name of the claim type
		/// </summary>
		[Column(TypeName = "VARCHAR")]
		[StringLength(20)]
		public string? Name { get; set; }
	}
}