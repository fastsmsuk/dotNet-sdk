using FastSms.Enums;
using FastSms.Exceptions;
using FastSms.Models.Responses;
using FastSms.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FastSms.Tests.UnitTests
{
    [TestClass]
    public class ReportsTestscs
    {
        [TestMethod]
        [TestCategory("Unit")]
        public void CheckGetReports()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("\"MessageID\",\"Username\",\"Destination\",\"Source\",\"Status\",\"Schedule Date\",\"Sent Date\",\"Delivery Date\"\n"
            +"\"55318001\",\"FS8561\",\"380965231000\",\"Lezgro\",\"Delivered\",\"09/06/2015 16:48:24\",\"09/06/2015 16:48:25\",\"09/06/2015 16:48:36\"\n"
            +"\"55367095\",\"FS8561\",\"380965231000\",\"Lezgro\",\"Delivered\",\"10/06/2015 07:45:00\",\"10/06/2015 07:45:01\",\"10/06/2015 07:45:12\"");
            var client = new FastSmsClient("Token", httpClient.Object);
            var result = client.GetReports(ReportType.Messages, "20141025000000", "20151027000000");
            Assert.AreEqual(result.Count, 2);
            Assert.IsTrue(result[0] is MessageReportResponse);
            Assert.IsTrue(result[1] is MessageReportResponse);
            Assert.AreEqual((result[0] as MessageReportResponse).MessageId, "55318001");
            Assert.AreEqual((result[1] as MessageReportResponse).MessageId, "55367095");
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof(FastSmsException))]
        public void CheckGetReportsError()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("-100");
            var client = new FastSmsClient("Token", httpClient.Object);
            var result = client.GetReports(ReportType.Messages, "20141025000000", "20151027000000");
        }
        [TestMethod]
        [TestCategory("Unit")]
        public void CheckGetReportsOutbox()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("\"MessageID\",\"Username\",\"Destination\",\"Status\",\"Schedule Date\",\"Sent Date\",\"Delivery Date\"\n"
+ "\"55318001\",\"FS8561\",\"380965231000\",\"Delivered\",\"09/06/2015 16:48:24\",\"10/06/2015 07:45:01\",\"10/06/2015 07:45:12\"");
            var client = new FastSmsClient("Token", httpClient.Object);
            var result = client.GetReports(ReportType.Outbox, "20141025000000", "20151027000000");
            Assert.AreEqual(result.Count, 1);
            Assert.IsTrue(result[0] is OutboxReportResponse);
            Assert.AreEqual((result[0] as OutboxReportResponse).MessageId, "55318001");
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void CheckGetReportsUsage()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("\"Status\",\"Messages\"\n"
            +"\"Delivered\",\"31\"\n"
            +"\"Undeliverable\",\"17\"\n"
            +"\"Failed\",\"14\"");
            var client = new FastSmsClient("Token", httpClient.Object);
            var result = client.GetReports(ReportType.Usage, "20141025000000", "20151027000000");
            Assert.AreEqual(result.Count, 3);
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void CheckGetReportsInboundMessages()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("\"MessageID\",\"From\",\"Number\",\"Message\",\"Received Date\",\"Status\"\n"
                + "\"55318001\",\"From\",\"380965231000\",\"Message\",\"09/06/2015 16:48:24\",\"Delivered\"");
            var client = new FastSmsClient("Token", httpClient.Object);
            var result = client.GetReports(ReportType.InboundMessages, "20141025000000", "20151027000000");
            Assert.AreEqual(result.Count, 1);
            Assert.IsTrue(result[0] is InboundMessagesReportResponse);
            Assert.AreEqual((result[0] as InboundMessagesReportResponse).MessageId, "55318001");
        }
    }
}
