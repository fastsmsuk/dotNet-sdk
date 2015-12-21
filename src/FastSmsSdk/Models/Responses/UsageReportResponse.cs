namespace FastSmsSdk.Models.Responses {
	/// <summary>
	///    Usage report model.
	/// </summary>
	public class UsageReportResponse : BaseReportResponse {
		/// <summary>
		///    Status.
		/// </summary>
		public string Status { get; set; }

		/// <summary>
		///    Messages.
		/// </summary>
		public string Messages { get; set; }
	}
}