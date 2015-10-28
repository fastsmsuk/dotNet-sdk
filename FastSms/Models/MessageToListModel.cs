namespace FastSms.Models {
	/// <summary>
	///    Message to list model.
	/// </summary>
	public class MessageToListModel : MessageToSendModel {
		/// <summary>
		///    List name.
		/// </summary>
		public string ListName { get; set; }
	}
}