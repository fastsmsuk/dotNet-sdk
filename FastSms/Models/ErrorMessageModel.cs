using Newtonsoft.Json;

namespace FastSms.Models {
	public class ErrorMessageModel {
		[JsonProperty ( PropertyName = "error" )]
		public string Number { get; set; }

		[JsonProperty ( PropertyName = "message" )]
		public string Message { get; set; }
	}
}