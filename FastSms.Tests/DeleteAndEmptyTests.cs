using FastSms.Exceptions;
using FastSms.Models;
using FastSms.Models.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastSms.Tests {
	[TestClass]
	public class DeleteAndEmptyTests {
		public Client Client;
		public CreateUserRequest UserModel;

		[TestInitialize]
		public void TestInitialize () {
			Client = new Client();
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckDeleteAllContactsBadToken () {
			Client = new Client( "Token" );
			Client.DeleteAllContacts();
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckDeleteAllGroupsBadToken () {
			Client = new Client( "Token" );
			Client.DeleteAllGroups();
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckDeleteGroupBadToken () {
			Client = new Client( "Token" );
			Client.DeleteGroup( "group1" );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckDeleteGroupBadName () {
			Client.DeleteGroup( "somegroup" );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckEmptyGroupBadToken () {
			Client = new Client( "Token" );
			Client.EmptyGroup( "group1" );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckEmptyGroupBadName () {
			Client.EmptyGroup( "somegroup" );
		}
	}
}