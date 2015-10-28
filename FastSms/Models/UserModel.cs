namespace FastSms.Models {
	/// <summary>
	///    User model.
	/// </summary>
	public class UserModel {
		/// <summary>
		///    Child username.
		/// </summary>
		public string ChildUsername { get; set; }

		/// <summary>
		///    Child password.
		/// </summary>
		public string ChildPassword { get; set; }

		/// <summary>
		///    Access level.
		/// </summary>
		public string AccessLevel { get; set; }

		/// <summary>
		///    First name.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		///    Last name.
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		///    Email.
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		///    Credits.
		/// </summary>
		public double Credits { get; set; }

		/// <summary>
		///    Credit reminder.
		/// </summary>
		public int CreditReminder { get; set; }

		/// <summary>
		///    Alert.
		/// </summary>
		public int Alert { get; set; }

		/// <summary>
		///    Telephone.
		/// </summary>
		public string Telephone { get; set; }
	}
}