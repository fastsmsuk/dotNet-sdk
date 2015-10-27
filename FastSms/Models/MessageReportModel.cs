namespace FastSms.Models {
	public class MessageReportModel : ReportModel {
		public string MessageId { get; set; }
		public string Username { get; set; }
		public string Destination { get; set; }
		public string Source { get; set; }
		public string Status { get; set; }
		public string ScheduleDate { get; set; }
		public string SentDate { get; set; }
		public string DeliveryDate { get; set; }
	}
}