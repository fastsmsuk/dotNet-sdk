namespace FastSms.Models {
	/// <summary>
	///    Message to group model.
	/// </summary>
	public class MessageToGroupModel : MessageToSendModel {
		/// <summary>
		///    Group name.
		/// </summary>
		public string GroupName { get; set; }
	}
}