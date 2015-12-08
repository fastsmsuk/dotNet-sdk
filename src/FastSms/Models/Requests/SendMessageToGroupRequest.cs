namespace FastSms.Models.Requests {
	/// <summary>
	///    Message to group model.
	/// </summary>
	public class MessageToGroupRequest : BaseSendMessageRequest {
		/// <summary>
		///    Group name.
		/// </summary>
		public string GroupName { get; set; }
	}
}