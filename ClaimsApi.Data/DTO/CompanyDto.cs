using ClaimsApi.Data.Entities;

namespace ClaimsApi.Data.DTO
{
	public class CompanyDto :
		AbstractDto<Company>
	{
		private readonly bool _populateClaims;

		#region Ctor

		public CompanyDto()
		{
		}

		public CompanyDto(Company? entity, bool populateClaims = false) :
			base(entity ?? new Company())
		{
			_populateClaims = populateClaims;
		}

		#endregion Ctor

		#region Overrides

		protected override void SetValuesFromEntity(Company entity)
		{
			this.Id = entity.Id;
			this.Name = entity.Name;
			this.Address1 = entity.Address1 ?? string.Empty;
			this.Address2 = entity.Address2;
			this.Address3 = entity.Address3;
			this.PostCode = entity.PostCode ?? string.Empty;
			this.Country = entity.Country ?? string.Empty;
			this.Active = entity.Active.GetValueOrDefault(false);
			this.InsuranceEndDate = entity.InsuranceEndDate ?? DateTime.MinValue;
			this.Identity = entity.Identity;

			if (_populateClaims)
			{
				var claims = entity.Claims.Select(s => new ClaimDto(s));
				Claims = new List<ClaimDto>(claims);
			}
		}

		#endregion Overrides

		#region Property Accessors

		public int? Id { get; private set; }

		public string? Name { get; set; }

		public string Address1 { get; set; } = string.Empty;

		public string? Address2 { get; set; }

		public string? Address3 { get; set; }

		public string PostCode { get; set; } = string.Empty;

		public string? Country { get; set; }

		public bool Active { get; set; }

		public DateTime InsuranceEndDate { get; set; } = DateTime.MinValue;

		public int Identity { get; set; }

		public ICollection<ClaimDto>? Claims { get; set; }

		/// <summary>
		/// Calculated property to determine if the company has a currently valid insurance policy
		/// </summary>
		public bool HasActiveInsurancePolicy
		{
			get
			{
				return InsuranceEndDate >= DateTime.Today;
			}
		}

		#endregion Property Accessors
	}
}