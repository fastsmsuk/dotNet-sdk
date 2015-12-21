using FastSms.Exceptions;
using FastSms.Models.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastSms.Tests.IntegrationTests {
	[TestClass]
	public class SendMessageTests {
		public FastSmsClient Client;

		[TestInitialize]
		public void TestInitialize () {
			Client = new FastSmsClient();
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckSendMessageToGroupBadToken () {
			var client = new FastSmsClient( "bad token" );
			client.SendMessage( new MessageToGroupRequest() );
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckSendMessageToGroupBadModelState () {
			var client = new FastSmsClient();
			client.SendMessage( new MessageToGroupRequest {
				GroupName = "bad group name",
				SourceAddress = "bad source",
				Body = "some text"
			} );
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckSendMessageToListBadToken () {
			var client = new FastSmsClient( "bad token" );
			client.SendMessage( new SendMessageToListRequest() );
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckSendMessageToListBadModelState () {
			var client = new FastSmsClient();
			client.SendMessage( new SendMessageToListRequest {
				ListName = "Bad list name",
				Body = "body",
				SourceAddress = ""
			} );
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckSendMessageToUserBadToken () {
			var client = new FastSmsClient( "bad token" );
			client.SendMessage( new SendMessageToUserRequest() );
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckSendMessageToUserBadModelState () {
			var client = new FastSmsClient();
			client.SendMessage( new SendMessageToUserRequest {
				DestinationAddress = "bad destination"
			} );
		}
	}
}