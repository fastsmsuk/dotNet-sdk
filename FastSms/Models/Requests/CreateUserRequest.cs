namespace FastSms.Models.Requests {
    /// <summary>
    ///    Request format for Action=CreateUser
    /// </summary>
    public class CreateUserRequest {
        /// <summary>
        ///    The username of the user you wish to create.
        /// </summary>
        public string ChildUsername { get; set; }

        /// <summary>
        ///    The password for the user.
        /// </summary>
        public string ChildPassword { get; set; }

        /// <summary>
        ///    What access level the user should have (Normal or Admin).
        /// </summary>
        public string AccessLevel { get; set; }

        /// <summary>
        ///    The first name of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///    The last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///    The email address of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
		///    (Optional) The telephone number of the user.
		/// </summary>
		public string Telephone { get; set; }

        /// <summary>
        ///    The telephone number of the user.
        /// </summary>
        public double Credits { get; set; }

        /// <summary>
        ///    (Optional) When to send the user a low credit warning email (number of credits left to trigger the email).
        /// </summary>
        public int CreditReminder { get; set; }

        /// <summary>
        ///    (Optional) After how many days of inactivity should an inactivity alert be sent.
        /// </summary>
        public int Alert { get; set; }
	}
}