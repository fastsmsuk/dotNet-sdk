using FastSms.Exceptions;
using FastSms.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FastSms.Tests.UnitTests
{
    [TestClass]
    public class DeleteAndEmptyTests
    {
        [TestMethod]
        [TestCategory("Unit")]
        public void CheckDeleteAllContacts()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("1");
            var client = new FastSmsClient("Token", httpClient.Object);
            client.DeleteAllContacts();
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof(FastSmsException))]
        public void CheckDeleteAllContactsError()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("-100");
            var client = new FastSmsClient("Token", httpClient.Object);
            client.DeleteAllContacts();
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void CheckDeleteAllGroups()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("1");
            var client = new FastSmsClient("Token", httpClient.Object);
            client.DeleteAllGroups();
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof(FastSmsException))]
        public void CheckDeleteAllGroupsError()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("-100");
            var client = new FastSmsClient("Token", httpClient.Object);
            client.DeleteAllGroups();
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void CheckDeleteGroup()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("1");
            var client = new FastSmsClient("Token", httpClient.Object);
            client.DeleteGroup("group1");
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof(FastSmsException))]
        public void CheckDeleteGroupError()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("-100");
            var client = new FastSmsClient("Token", httpClient.Object);
            client.DeleteGroup("somegroup");
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void CheckEmptyGroup()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("1");
            var client = new FastSmsClient("Token", httpClient.Object);
            client.EmptyGroup("group1");
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof(FastSmsException))]
        public void CheckEmptyGroupError()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("-100");
            var client = new FastSmsClient("Token", httpClient.Object);
            client.EmptyGroup("somegroup");
        }
    }
}
