using FastSms.Exceptions;
using FastSms.Models.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastSms.Tests.IntegrationTests {
	[TestClass]
	public class UserTests {
		public FastSmsClient Client;
		public CreateUserRequest UserModel;

		[TestInitialize]
		public void TestInitialize () {
			Client = new FastSmsClient();
			UserModel = new CreateUserRequest {
				FirstName = "Name",
				LastName = "LastName",
				Email = "email",
				AccessLevel = "Normal",
				ChildUsername = "username",
				ChildPassword = "12345",
				Credits = 22
			};
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckCreateUserBadToken () {
			Client = new FastSmsClient( "Token" );
			Client.CreateUser( UserModel );
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckCreateUserBadName () {
			UserModel.FirstName = "";
			Client.CreateUser( UserModel );
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckCreateUserBadLastName () {
			UserModel.LastName = "";
			Client.CreateUser( UserModel );
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckCreateUserBadAccess () {
			UserModel.FirstName = "AccessLevel";
			Client.CreateUser( UserModel );
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckCreateUserBadUsername () {
			UserModel.ChildUsername = "";
			Client.CreateUser( UserModel );
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckCreateUserBadPassword () {
			UserModel.ChildPassword = "";
			Client.CreateUser( UserModel );
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckCreateUserBadEmail () {
			UserModel.Email = "";
			Client.CreateUser( UserModel );
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckCreateUserBadCredits () {
			UserModel.Credits = -1;
			Client.CreateUser( UserModel );
		}
	}
}