namespace FastSms.Models {
	public class MessageToSendModel {
		public string SourceAddress { get; set; }
		public string Body { get; set; }
		public string ScheduleDate { get; set; }
		public string SourceTon { get; set; }
		public int? ValidityPeriod { get; set; }
		public int? GetAllMessageIDs { get; set; }
		public int? GetBgSendId { get; set; }
   }
}