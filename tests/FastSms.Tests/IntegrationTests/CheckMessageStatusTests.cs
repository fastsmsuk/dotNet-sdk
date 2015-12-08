using FastSms.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastSms.Tests.IntegrationTests {
	[TestClass]
	public class CheckMessageStatusTests {
		public FastSmsClient Client;

		[TestInitialize]
		public void TestInitialize () {
			Client = new FastSmsClient();
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckMessageStatusNotNumer () {
			Client.CheckMessageStatus( "message" );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckMessageStatusBadToken () {
			Client = new FastSmsClient( "Token" );
			Client.CheckMessageStatus( "73786923" );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckMessageStatusBadNumber () {
			Client.CheckMessageStatus( "1" );
		}

		[TestMethod]
		public void CheckMessageStatusDelivered () {
			Assert.AreEqual( "Delivered", Client.CheckMessageStatus( "73786923" ), "This message is delivered" );
		}

		[TestMethod]
		public void CheckMessageStatusUndeliverable () {
			Assert.AreEqual( "Undeliverable", Client.CheckMessageStatus( "73959607" ), "This message is undelivereble" );
		}
	}
}