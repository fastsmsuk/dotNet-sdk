namespace FastSms.Models.Requests {
	/// <summary>
	///    Message to list model.
	/// </summary>
	public class SendMessageToListRequest : BaseSendMessageRequest {
		/// <summary>
		///    List name.
		/// </summary>
		public string ListName { get; set; }
	}
}