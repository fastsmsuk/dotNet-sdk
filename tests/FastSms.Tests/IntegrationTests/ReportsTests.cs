using FastSms.Enums;
using FastSms.Exceptions;
using FastSms.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastSms.Tests.IntegrationTests {
	[TestClass]
	public class ReportsTests {
		public FastSmsClient Client;

		[TestInitialize]
		public void TestInitialize () {
			Client = new FastSmsClient();
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckGetReportsBadToken () {
			var client = new FastSmsClient( "Token" );
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