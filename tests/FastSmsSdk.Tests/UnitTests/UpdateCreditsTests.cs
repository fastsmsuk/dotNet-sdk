using FastSmsSdk;
using FastSmsSdk.Exceptions;
using FastSmsSdk.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FastSms.Tests.UnitTests
{
    [TestClass]
    public class UpdateCreditsTests
    {
        [TestMethod]
        [TestCategory("Unit")]
        public void CheckUpdateCredits()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("1");
            var client = new FastSmsClient("Token", httpClient.Object);
            client.UpdateCredits("user",2);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof(FastSmsException))]
        public void CheckUpdateCreditsError()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("-100");
            var client = new FastSmsClient("Token", httpClient.Object);
            client.UpdateCredits("user2", 3);
        }
    }
}
