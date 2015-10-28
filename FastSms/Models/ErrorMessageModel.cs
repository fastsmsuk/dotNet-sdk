using Newtonsoft.Json;

namespace FastSms.Models {
	/// <summary>
	///    Error message model.
	/// </summary>
	public class ErrorMessageModel {
		/// <summary>
		///    Number.
		/// </summary>
		[JsonProperty ( PropertyName = "error" )]
		public string Number { get; set; }

		/// <summary>
		///    Message.
		/// </summary>
		[JsonProperty ( PropertyName = "message" )]
		public string Message { get; set; }
	}
}