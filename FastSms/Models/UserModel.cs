namespace FastSms.Models {
	public class UserModel {
		public string ChildUsername { get; set; }
		public string ChildPassword { get; set; }
		public string AccessLevel { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public double Credits { get; set; }
		public int CreditReminder { get; set; }
		public int Alert { get; set; }
		public string Telephone { get; set; }
	}
}