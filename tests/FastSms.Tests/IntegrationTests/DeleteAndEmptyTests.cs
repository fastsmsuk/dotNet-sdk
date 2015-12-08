using FastSms.Exceptions;
using FastSms.Models.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastSms.Tests.IntegrationTests {
	[TestClass]
	public class DeleteAndEmptyTests {
		public FastSmsClient Client;
		public CreateUserRequest UserModel;

		[TestInitialize]
		public void TestInitialize () {
			Client = new FastSmsClient();
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckDeleteAllContactsBadToken () {
			Client = new FastSmsClient( "Token" );
			Client.DeleteAllContacts();
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckDeleteAllGroupsBadToken () {
			Client = new FastSmsClient( "Token" );
			Client.DeleteAllGroups();
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckDeleteGroupBadToken () {
			Client = new FastSmsClient( "Token" );
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
			Client = new FastSmsClient( "Token" );
			Client.EmptyGroup( "group1" );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckEmptyGroupBadName () {
			Client.EmptyGroup( "somegroup" );
		}
	}
}