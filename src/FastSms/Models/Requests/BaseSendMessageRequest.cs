namespace FastSms.Models.Requests {
    /// <summary>
    ///    Request format for Action=Send
    /// </summary>
    public abstract class BaseSendMessageRequest {
        /// <summary>
        ///    The Source Address for the message. If this is alphanumeric, it must be 11 or less characters.
        ///    All GSM characters are valid, however operators and handsets may support restricted character sets.
        ///    We recommend you stick to A-Z, a-z, 0-9 and space.
        /// </summary>
        public string SourceAddress { get; set; }

        /// <summary>
        ///    The Message Body (max 459 characters).
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        ///    The date that the message should be sent (YYYYMMDDHHMMSS).
        /// </summary>
        public string ScheduleDate { get; set; }

        /// <summary>
        ///    The Type Of Number for the source address (1 for international, 5 for alphanumeric).
        /// </summary>
        public string SourceTon { get; set; }

        /// <summary>
        ///    The period in seconds that the message will be tried for (maximum 86400 = 24 hours). 
        ///    Once this expires, the message will no longer be attempted to be delivered.
        /// </summary>
        public int? ValidityPeriod { get; set; }

        /// <summary>
        ///    If the message is longer than 160 characters, the system by default will return only the first ID for each message.
        ///    Set this parameter to 1 to return all the Ids for each part of each message.
        /// </summary>
        public int? GetAllMessageIDs { get; set; }

        /// <summary>
        ///    If you send to a distlist and set this parameter to 1 the BGSendID for the dist list will be returned.
        ///    For future proofing, this could be a comma separated list of values, should the send be split into multiple sends.
        /// </summary>
        public int? GetBgSendId { get; set; }
	}
}