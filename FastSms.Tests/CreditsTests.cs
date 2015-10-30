using FastSms.Exceptions;
using FastSms.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastSms.Tests {
	[TestClass]
	public class CreditsTests {
		public Client Client;
		public UserModel UserModel;

		[TestInitialize]
		public void TestInitialize () {
			Client = new Client();
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckCreditsBadToken () {
			Client = new Client( "Token" );
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
			Client = new Client( "Token" );
			Client.UpdateCredits( "NameZ1111", 23 );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckUpdateCreditsBadName () {
			Client.UpdateCredits( "Someone", 23 );
		}
	}
}