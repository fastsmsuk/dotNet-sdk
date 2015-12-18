using FastSms.Exceptions;
using FastSms.Models.Requests;
using FastSms.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FastSms.Tests.UnitTests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        [TestCategory("Unit")]
        public void CheckCreateUser()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("1");
            var client = new FastSmsClient("Token", httpClient.Object);
            client.CreateUser(new CreateUserRequest());
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof(FastSmsException))]
        public void CheckCreateUserError()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("-100");
            var client = new FastSmsClient("Token", httpClient.Object);
            client.CreateUser(new CreateUserRequest());
        }
    }
}
