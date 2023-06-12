namespace ClaimsApi.Models
{
	public class ClaimUpdateRequestModel
	{
		public string Ucr { get; set; } = string.Empty;
		public DateTime? ClaimDate { get; set; }

		public DateTime? LossDate { get; set; }

		public string? AssuredName { get; set; }

		public decimal? IncurredLoss { get; set; }

		public bool Closed { get; set; }
	}
}