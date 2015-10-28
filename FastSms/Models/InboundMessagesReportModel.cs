namespace FastSms.Models {
	/// <summary>
	///    Inbound messages report model.
	/// </summary>
	public class InboundMessagesReportModel : ReportModel {
		/// <summary>
		///    Message id.
		/// </summary>
		public string MessageId { get; set; }

		/// <summary>
		///    From.
		/// </summary>
		public string From { get; set; }

		/// <summary>
		///    Number.
		/// </summary>
		public string Number { get; set; }

		/// <summary>
		///    Message.
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		///    Receive date.
		/// </summary>
		public string ReceivedDate { get; set; }

		/// <summary>
		///    Status.
		/// </summary>
		public string Status { get; set; }
	}
}