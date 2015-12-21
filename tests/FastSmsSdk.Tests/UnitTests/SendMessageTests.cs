using FastSmsSdk;
using FastSmsSdk.Exceptions;
using FastSmsSdk.Models.Requests;
using FastSmsSdk.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FastSms.Tests.UnitTests
{
    [TestClass]
    public class SendMessageTests
    {
        [TestMethod]
        [TestCategory("Unit")]
        public void CheckSendMessageToGroup()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("1");
            var client = new FastSmsClient("Token", httpClient.Object);
            client.SendMessage(new MessageToGroupRequest());
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof(FastSmsException))]
        public void CheckSendMessageToGroupError()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("-100");
            var client = new FastSmsClient("Token", httpClient.Object);
            client.SendMessage(new MessageToGroupRequest());
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void CheckSendMessageToList()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("1");
            var client = new FastSmsClient("Token", httpClient.Object);
            client.SendMessage(new SendMessageToListRequest());
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof(FastSmsException))]
        public void CheckSendMessageToListError()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("-100");
            var client = new FastSmsClient("Token", httpClient.Object);
            client.SendMessage(new SendMessageToListRequest());
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void CheckSendMessageToUser()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("1");
            var client = new FastSmsClient("Token", httpClient.Object);
            client.SendMessage(new SendMessageToUserRequest());
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof(FastSmsException))]
        public void CheckSendMessageToUserError()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("-100");
            var client = new FastSmsClient("Token", httpClient.Object);
            client.SendMessage(new SendMessageToUserRequest());
        }
    }
}
