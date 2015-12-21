namespace FastSmsSdk.Models.Requests {
    /// <summary>
    ///    Request format for Action=CreateUser
    /// </summary>
    public class CreateUserRequest {

        public CreateUserRequest(){}

        public CreateUserRequest(string childUsername, string childPassword, string accessLevel, string firstName, string lastName,
            string email, string telephone, double credits, int creditReminder, int alert)
        {
            ChildUsername = childUsername;
            ChildPassword = childPassword;
            AccessLevel = accessLevel;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Telephone = telephone;
            Credits = credits;
            CreditReminder = creditReminder;
            Alert = alert;
        }

        public CreateUserRequest(string userName, string telephone)
        {
            ChildUsername = userName;
            ChildPassword = string.Empty;
            AccessLevel = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Telephone = telephone;
            Credits = 0;
            CreditReminder = 0;
            Alert = 0;
        }
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