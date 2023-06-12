namespace ClaimsApi.Models
{
	public abstract class AbstractResponseModel<T> where T : class
	{
		protected AbstractResponseModel(T? data)
		{
			Data = data;
		}

		/// <summary>
		/// Indicates success or failure of the operation
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// Provides a message suitable for the state of <see cref="Success"/>
		/// </summary>
		public string Message { get; set; } = string.Empty;

		/// <summary>
		/// Placeholder for the data payload
		/// </summary>
		public T? Data { get; }
	}
}