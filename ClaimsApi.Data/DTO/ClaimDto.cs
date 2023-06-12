using ClaimsApi.Data.Entities;

namespace ClaimsApi.Data.DTO
{
	public class ClaimDto :
		AbstractDto<Claim>
	{
		#region Ctor

		public ClaimDto(Claim claim) :
			base(claim)
		{
		}

		#endregion Ctor

		#region Overrides

		protected override void SetValuesFromEntity(Claim entity)
		{
			_ = entity ?? throw new ArgumentNullException(nameof(entity));

			this.Ucr = entity.Ucr ?? "";
			this.CompanyId = entity.CompanyId;
			this.ClaimDate = entity.ClaimDate ?? DateTime.MinValue;
			this.LossDate = entity.LossDate ?? DateTime.MinValue;
			this.AssuredName = entity.AssuredName;
			this.IncurredLoss = entity.IncurredLoss.GetValueOrDefault(0);
			this.Closed = entity.Closed ?? false;
			this.Company = new CompanyDto(entity.Company, false);
			this.Identity = entity.Identity;
		}

		#endregion Overrides

		#region PropertyAccessors

		public string Ucr { get; private set; } = string.Empty;

		public int? CompanyId { get; private set; }

		public DateTime ClaimDate { get; set; }

		public DateTime LossDate { get; set; }

		public string? AssuredName { get; set; }

		public decimal IncurredLoss { get; set; }

		public bool Closed { get; set; }

		public CompanyDto? Company { get; private set; }

		public int Identity { get; private set; }

		/// <summary>
		/// Calculated field
		/// </summary>
		/// <remarks>
		/// No bounds checking (other than checking for the "no date present" value of
		/// DateTime.MinValue), therefore if a claim date is set in the future, the result will be a
		/// negative value
		/// </remarks>
		public int ClaimAgeInDays
		{
			get
			{
				return ClaimDate == DateTime.MinValue
					? 0
					: DateTime.Today.Subtract(ClaimDate.Date).Days;
			}
		}

		#endregion PropertyAccessors
	}
}