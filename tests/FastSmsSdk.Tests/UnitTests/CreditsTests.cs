using FastSms.Exceptions;
using FastSms.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FastSms.Tests.UnitTests
{
    [TestClass]
    public class CreditsTests
    {
        [TestMethod]
        [TestCategory("Unit")]
        public void CheckCreditsFirstMoq()
        {
            var httpClient =
            Mock.Of<IHttpClient>(d => d.GetResponse("https://my.fastsms.co.uk/api?Token=Token&Action=CheckCredits", true) == "0m");
            var client = new FastSmsClient("Token", httpClient);
            var result = client.CheckCredits();
            Assert.AreEqual(result, 0);
        }
    }
}
