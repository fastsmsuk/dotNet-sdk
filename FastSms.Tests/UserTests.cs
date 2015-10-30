using FastSms.Exceptions;
using FastSms.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastSms.Tests {
	[TestClass]
	public class UserTests {
		public Client Client;
		public UserModel UserModel;

		[TestInitialize]
		public void TestInitialize () {
			Client = new Client();
			UserModel = new UserModel {
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
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckCreateUserBadToken () {
			Client = new Client( "Token" );
			Client.CreateUser( UserModel );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckCreateUserBadName () {
			UserModel.FirstName = "";
			Client.CreateUser( UserModel );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckCreateUserBadLastName () {
			UserModel.LastName = "";
			Client.CreateUser( UserModel );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckCreateUserBadAccess () {
			UserModel.FirstName = "AccessLevel";
			Client.CreateUser( UserModel );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckCreateUserBadUsername () {
			UserModel.ChildUsername = "";
			Client.CreateUser( UserModel );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckCreateUserBadPassword () {
			UserModel.ChildPassword = "";
			Client.CreateUser( UserModel );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckCreateUserBadEmail () {
			UserModel.Email = "";
			Client.CreateUser( UserModel );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckCreateUserBadCredits () {
			UserModel.Credits = -1;
			Client.CreateUser( UserModel );
		}
	}
}