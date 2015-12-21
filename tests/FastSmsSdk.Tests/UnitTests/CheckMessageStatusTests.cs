using FastSmsSdk;
using FastSmsSdk.Exceptions;
using FastSmsSdk.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FastSms.Tests.UnitTests
{
    [TestClass]
    public class CheckMessageStatusTests
    {
        [TestMethod]
        [TestCategory("Unit")]
        public void TestMessageStatusDelivered()
        {
            var httpClient =new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("Delivered");
            var client = new FastSmsClient("Token", httpClient.Object);
            var result = client.CheckMessageStatus("12");
            Assert.AreEqual(result, "Delivered");
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void TestMessageStatusUndeliverable()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("Undeliverable");
            var client = new FastSmsClient("Token", httpClient.Object);
            var result = client.CheckMessageStatus("15");
            Assert.AreEqual(result, "Undeliverable");
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof(FastSmsException))]
        public void TestMessageStatusError()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("-100");
            var client = new FastSmsClient("Token", httpClient.Object);
            var result = client.CheckMessageStatus("16");
        }
    }
}
