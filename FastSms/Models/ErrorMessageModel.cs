using Newtonsoft.Json;

namespace FastSms.Models {
	public class ErrorMessageModel {
		[JsonProperty(PropertyName = "error")]
		public string Error { get; set; }
		[JsonProperty( PropertyName = "message" )]
		public string Message { get; set; }
	}
}