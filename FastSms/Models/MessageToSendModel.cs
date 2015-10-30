namespace FastSms.Models {
	/// <summary>
	///    Message to send model.
	/// </summary>
	public class MessageToSendModel {
		/// <summary>
		///    Source address.
		/// </summary>
		public string SourceAddress { get; set; }

		/// <summary>
		///    Body.
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		///    Schedule date.
		/// </summary>
		public string ScheduleDate { get; set; }

		/// <summary>
		///    Source TON.
		/// </summary>
		public string SourceTon { get; set; }

		/// <summary>
		///    Validity period.
		/// </summary>
		public int? ValidityPeriod { get; set; }

		/// <summary>
		///    Get all message ids.
		/// </summary>
		public int? GetAllMessageIDs { get; set; }

		/// <summary>
		///    Get background send id.
		/// </summary>
		public int? GetBgSendId { get; set; }
	}
}