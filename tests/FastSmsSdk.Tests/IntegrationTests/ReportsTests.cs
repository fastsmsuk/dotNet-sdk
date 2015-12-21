using FastSmsSdk;
using FastSmsSdk.Enums;
using FastSmsSdk.Exceptions;
using FastSmsSdk.Models.Responses;
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
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckGetReportsBadToken () {
            var client = new FastSmsClient("Token");
            client.GetReports(ReportType.Messages, "20151025000000", "20151027000000");
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckGetReportsWrongDatesFormat () {
			Client.GetReports( ReportType.Messages, "bbbbbbbbbbbbb", "20151027000000" );
		}

        [TestMethod]
        [TestCategory("Integration")]
		public void CheckGetReports () {
			var list = Client.GetReports( ReportType.Messages, "20151025000000", "20151027000000" );
			Assert.IsNotNull( list );
		}

        [TestMethod]
        [TestCategory("Integration")]
		public void CheckGetReportsReturnedType () {
			var list = Client.GetReports( ReportType.Messages, "20151025000000", "20151027000000" );
			Assert.IsTrue( list[0] is MessageReportResponse );
		}
	}
}