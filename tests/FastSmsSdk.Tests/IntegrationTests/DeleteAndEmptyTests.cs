using FastSmsSdk;
using FastSmsSdk.Exceptions;
using FastSmsSdk.Models.Requests;
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
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckDeleteAllContactsBadToken () {
			Client = new FastSmsClient( "Token" );
			Client.DeleteAllContacts();
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckDeleteAllGroupsBadToken () {
			Client = new FastSmsClient( "Token" );
			Client.DeleteAllGroups();
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckDeleteGroupBadToken () {
			Client = new FastSmsClient( "Token" );
			Client.DeleteGroup( "group1" );
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckDeleteGroupBadName () {
			Client.DeleteGroup( "somegroup" );
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckEmptyGroupBadToken () {
			Client = new FastSmsClient( "Token" );
			Client.EmptyGroup( "group1" );
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckEmptyGroupBadName () {
			Client.EmptyGroup( "somegroup" );
		}
	}
}