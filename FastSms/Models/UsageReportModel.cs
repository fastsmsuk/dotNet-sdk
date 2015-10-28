namespace FastSms.Models {
	/// <summary>
	///    Usage report model.
	/// </summary>
	public class UsageReportModel : ReportModel {
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