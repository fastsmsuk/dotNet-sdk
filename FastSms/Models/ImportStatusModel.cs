namespace FastSms.Models {
	public class ImportStatusModel {
		public ImportStatusModel ( int number, string status ) {
			Number = number;
			Status = status;
		}

		public int Number { get; set; }
		public string Status { get; set; }
	}
}