using System.Collections.Generic;
using FastSmsSdk;
using FastSmsSdk.Exceptions;
using FastSmsSdk.Models.Requests;
using FastSmsSdk.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FastSms.Tests.UnitTests
{
    [TestClass]
    public class ContactsTests
    {
        [TestMethod]
        [TestCategory("Unit")]
        public void ContactsTestSuccess()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("1 : Success");
            
            
            var client = new FastSmsClient("Token", httpClient.Object);
            var listParameters = new List<ImportContactsRequest>
            {
                new ImportContactsRequest
                {
                    Name = "NameZ1111",
                    Number = "0984784",
                    Group1 = "group1"
                },
            };
            var result = client.ImportContactsCsv(listParameters);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].Status, "Success");
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void ContactsTestFailed()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("1 : Failed");


            var client = new FastSmsClient("Token", httpClient.Object);
            var listParameters = new List<ImportContactsRequest>
            {
                new ImportContactsRequest
                {
                    Name = "NameZ1111",
                    Number = "0984784",
                    Group1 = "group1"
                },
            };
            var result = client.ImportContactsCsv(listParameters);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].Status, "Failed");
        }

        [TestMethod]
        [TestCategory("Unit")]
        [ExpectedException(typeof(FastSmsException))]
        public void ContactsTestError()
        {
            var httpClient = new Mock<IHttpClient>();
            httpClient.Setup(d => d.GetResponse(It.IsAny<string>(), true)).Returns("-100");


            var client = new FastSmsClient("Token", httpClient.Object);
            var listParameters = new List<ImportContactsRequest>
            {
                new ImportContactsRequest
                {
                    Name = "NameZ1111",
                    Number = "0984784",
                    Group1 = "group1"
                },
            };
            var result = client.ImportContactsCsv(listParameters);
        }
    }
}
