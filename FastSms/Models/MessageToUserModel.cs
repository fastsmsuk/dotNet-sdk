namespace FastSms.Models {
	/// <summary>
	///    Message to user model.
	/// </summary>
	public class MessageToUserModel : MessageToSendModel {
		/// <summary>
		///    Destination address.
		/// </summary>
		public string DestinationAddress { get; set; }
	}
}