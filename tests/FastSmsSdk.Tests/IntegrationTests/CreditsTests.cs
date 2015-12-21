using FastSmsSdk;
using FastSmsSdk.Exceptions;
using FastSmsSdk.Models.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastSms.Tests.IntegrationTests {
	[TestClass]
	public class CreditsTests {
		public FastSmsClient Client;
		public CreateUserRequest UserModel;

		[TestInitialize]
		public void TestInitialize () {
			Client = new FastSmsClient();
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckCreditsBadToken () {
			Client = new FastSmsClient( "Token" );
			Client.CheckCredits();
		}

        [TestMethod]
        [TestCategory("Integration")]
		public void CheckCreditsNotNull () {
			Assert.IsNotNull( Client.CheckCredits() );
		}

        [TestMethod]
        [TestCategory("Integration")]
		public void CheckCreditsReturnGraterZero () {
			Assert.IsTrue( Client.CheckCredits() > 0 );
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckUpdateCreditsBadToken () {
			Client = new FastSmsClient( "Token" );
			Client.UpdateCredits( "NameZ1111", 23 );
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckUpdateCreditsBadName () {
			Client.UpdateCredits( "Someone", 23 );
		}
	}
}