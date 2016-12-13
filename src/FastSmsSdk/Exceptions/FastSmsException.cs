using System;
namespace FastSmsSdk.Exceptions {
	/// <summary>
	///    API Exception.
	/// </summary>
	public class FastSmsException : Exception {
		public FastSmsException () {
		}

	    public FastSmsException ( string errorCode ) {
			Code = errorCode;
            string error = null;
            if (FastSmsErrors.Errors.ContainsKey(errorCode))
                error = FastSmsErrors.Errors[errorCode];
			Message = error ?? "N/A";
		}

		public string Code { get; set; }
		public new string Message { get; set; }
	}
}