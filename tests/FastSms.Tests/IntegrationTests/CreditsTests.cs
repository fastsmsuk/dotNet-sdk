using FastSms.Exceptions;
using FastSms.Models.Requests;
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
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckCreditsBadToken () {
			Client = new FastSmsClient( "Token" );
			Client.CheckCredits();
		}

		[TestMethod]
		public void CheckCreditsNotNull () {
			Assert.IsNotNull( Client.CheckCredits() );
		}

		[TestMethod]
		public void CheckCreditsReturnGraterZero () {
			Assert.IsTrue( Client.CheckCredits() > 0 );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckUpdateCreditsBadToken () {
			Client = new FastSmsClient( "Token" );
			Client.UpdateCredits( "NameZ1111", 23 );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckUpdateCreditsBadName () {
			Client.UpdateCredits( "Someone", 23 );
		}
	}
}