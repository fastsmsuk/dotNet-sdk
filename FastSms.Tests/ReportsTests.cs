using FastSms.Common;
using FastSms.Enums;
using FastSms.Exceptions;
using FastSms.Models;
using FastSms.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastSms.Tests {
	[TestClass]
	public class ReportsTests {
		public Client Client;

		[TestInitialize]
		public void TestInitialize () {
			Client = new Client();
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckGetReportsBadToken () {
			var client = new Client( "Token" );
			client.GetReports( ReportType.Messages, "20151025000000", "20151027000000" );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckGetReportsWrongDatesFormat () {
			Client.GetReports( ReportType.Messages, "bbbbbbbbbbbbb", "20151027000000" );
		}

		[TestMethod]
		public void CheckGetReports () {
			var list = Client.GetReports( ReportType.Messages, "20151025000000", "20151027000000" );
			Assert.IsNotNull( list );
		}

		[TestMethod]
		public void CheckGetReportsReturnedType () {
			var list = Client.GetReports( ReportType.Messages, "20151025000000", "20151027000000" );
			Assert.IsTrue( list[0] is MessageReportResponse );
		}
	}
}