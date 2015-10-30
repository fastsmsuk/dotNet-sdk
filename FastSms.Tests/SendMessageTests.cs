using FastSms.Exceptions;
using FastSms.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastSms.Tests {
	[TestClass]
	public class SendMessageTests {
		public Client Client;

		[TestInitialize]
		public void TestInitialize () {
			Client = new Client();
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckSendMessageToGroupBadToken () {
			var client = new Client( "bad token" );
			client.SendMessage( new MessageToGroupModel() );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckSendMessageToGroupBadModelState () {
			var client = new Client();
			client.SendMessage( new MessageToGroupModel {
				GroupName = "bad group name",
				SourceAddress = "bad source",
				Body = "some text"
			} );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckSendMessageToListBadToken () {
			var client = new Client( "bad token" );
			client.SendMessage( new MessageToListModel() );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckSendMessageToListBadModelState () {
			var client = new Client();
			client.SendMessage( new MessageToListModel {
				ListName = "Bad list name",
				Body = "body",
				SourceAddress = ""
			} );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckSendMessageToUserBadToken () {
			var client = new Client( "bad token" );
			client.SendMessage( new MessageToUserModel() );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckSendMessageToUserBadModelState () {
			var client = new Client();
			client.SendMessage( new MessageToUserModel {
				DestinationAddress = "bad destination"
			} );
		}
	}
}