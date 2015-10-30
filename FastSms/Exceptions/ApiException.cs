using System;
using System.Linq;
using FastSms.Common;

namespace FastSms.Exceptions {
	/// <summary>
	///    API Exception.
	/// </summary>
	public class ApiException : Exception {
		public ApiException () {
		}

		public ApiException ( string errorCode ) {
			Code = errorCode;

			var error = Constants.ErrorList.FirstOrDefault( item => item.Key == errorCode ).Value;
			Message = error ?? "N/A";
		}

		public string Code { get; set; }
		public override string Message { get; }
	}
}