namespace FastSms.Models {
	/// <summary>
	///    Message model.
	/// </summary>
	public class MessageModel {
		/// <summary>
		///    Message id.
		/// </summary>
		public string MessageId { get; set; }

		/// <summary>
		///    Destination.
		/// </summary>
		public string Destination { get; set; }

		/// <summary>
		///    Status.
		/// </summary>
		public string Status { get; set; }
	}
}