namespace FastSmsSdk.Models.Requests {
    /// <summary>
    ///    Sends a message. The message ID or error code will be returned in the content of the Page. 
    ///    If multiple numbers are submitted, then multiple IDs / error codes will be returned, separated by commas
    /// </summary>
    public class SendMessageToUserRequest : BaseSendMessageRequest {
        /// <summary>
        ///    The Destination Address(es) to send the message to. If you wish to send to multiple numbers, they should be separated by a comma.
        ///    When submitting multiple numbers, you should use the POST method rather than the GET method.To send to a list,
        ///    set the DestinationAddress parameter to “List” and add a new parameter “ListName” with the name of the list to send to.
        ///    For a group set the DestinationAddress parameter to “Group” and add a new parameter “GroupName” with the name of the group to 
        ///    send to.If the send is successful, the API will return 1. If not, a negative error code will be returned.Note that these sends may
        ///    occur in the background if the group/list contains more than 200 entries.
        /// </summary>
        public string DestinationAddress { get; set; }
	}
}