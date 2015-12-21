namespace FastSmsSdk.Models.Responses {
	/// <summary>
	///    Error message model.
	/// </summary>
	public class ErrorMessageResponse {
		/// <summary>
		///    Number.
		/// </summary>
		//[JsonProperty ( PropertyName = "error" )]
		public string Number { get; set; }

		/// <summary>
		///    Message.
		/// </summary>
		//[JsonProperty ( PropertyName = "message" )]
		public string Message { get; set; }
	}
}