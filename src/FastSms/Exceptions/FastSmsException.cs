using System;
using System.Linq;

namespace FastSms.Exceptions {
	/// <summary>
	///    API Exception.
	/// </summary>
	public class FastSmsException : Exception {
		public FastSmsException () {
		}

	    public FastSmsException ( string errorCode ) {
			Code = errorCode;

			var error = FastSmsErrors.Errors.FirstOrDefault( item => item.Key == errorCode ).Value;
			Message = error ?? "N/A";
		}

		public string Code { get; set; }
		public new string Message { get; set; }
	}
}