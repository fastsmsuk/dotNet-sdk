using System.Collections.Generic;
using FastSms.Common;
using FastSms.Exceptions;
using FastSms.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastSms.Tests {
	[TestClass]
	public class UnitTest {
		public Client Client;
		public List<ContactsCSVModel> ContactModelList;
		public List<ImportStatusModel> ImportContactsCsvResults;
		public UserModel UserModel;

		[TestInitialize]
		public void TestInitialize () {
			Client = new Client();
			Client.DeleteAllContacts();
			ContactModelList = new List<ContactsCSVModel> {
				new ContactsCSVModel {
					Name = "NameZ1111",
					Number = "0984784",
					Group1 = "group1"
				},
				new ContactsCSVModel {
					Name = "NameZ2111",
					Number = "0984724344555842",
					Group1 = "group1_2",
					Group2 = "group2_2",
					Group3 = "group3_3"
				},
				new ContactsCSVModel {
					Name = "",
					Number = "0984734442842",
					Group1 = "group1",
					Group2 = "group2"
				},
				new ContactsCSVModel {
					Name = "NZame3111",
					Number = "",
					Group1 = "group1",
					Group2 = "group2"
				},
				new ContactsCSVModel {
					Name = "NZame4111",
					Number = "somenumber",
					Group1 = "group1",
					Group2 = "group2"
				},
				new ContactsCSVModel {
					Name = "ZName5111",
					Number = "35682258"
				},
				new ContactsCSVModel {
					Name = "NameZ1111",
					Number = "3568234534258",
					Group1 = "group1_6"
				},
				new ContactsCSVModel {
					Name = "Name6111Z",
					Number = "0984784",
					Group1 = "group1_7"
				}
			};

			ImportContactsCsvResults = Client.ImportContactsCsv( ContactModelList );

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
		public void CheckGetReportBadToken () {
			var client = new Client( "Token" );
			client.GetReports( ReportType.Messages, "20151025000000", "20151027000000" );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckGetReportsWrongDatesFormat () {
			Client.GetReports( ReportType.Messages, "bbbbbbbbbbbbb", "20151027000000" );
		}

		[TestMethod]
		public void CheckGetReports () {
			var list = Client.GetReports( ReportType.Messages, "20151025000000", "20151027000000" );
			Assert.IsNotNull( list );
		}

		[TestMethod]
		public void CheckGetReportsReturnedType () {
			var list = Client.GetReports( ReportType.Messages, "20151025000000", "20151027000000" );
			Assert.IsTrue( list[0] is MessageReportModel );
		}

		[TestMethod]
		public void CheckImportContactsCsvSuccess () {
			Assert.AreEqual( "Success", ImportContactsCsvResults[0].Status );
		}

		[TestMethod]
		public void CheckImportContactsCsvNoName () {
			Assert.AreEqual( "Failed", ImportContactsCsvResults[2].Status );
		}

		[TestMethod]
		public void CheckImportContactsCsvNoNumber () {
			Assert.AreEqual( "Failed", ImportContactsCsvResults[3].Status );
		}

		[TestMethod]
		public void CheckImportContactsCsvDuplicateName () {
			Assert.AreEqual( "DuplicateName", ImportContactsCsvResults[6].Status );
		}

		[TestMethod]
		public void CheckImportContactsCsvDuplicateNumber () {
			Assert.AreEqual( "DuplicateNumber", ImportContactsCsvResults[7].Status );
		}

		[TestMethod]
		public void CheckImportContactsCsvWithIgnoreDupes () {
			Client.DeleteAllContacts();
			ImportContactsCsvResults = Client.ImportContactsCsv( ContactModelList, 1 );
			Assert.AreEqual( "Success", ImportContactsCsvResults[6].Status );
		}

		[TestMethod]
		public void CheckImportContactsCsvBadNumber () {
			Assert.AreEqual( "Failed", ImportContactsCsvResults[4].Status );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckImportContactsCsvBadToken () {
			var newClient = new Client( "Token" );
			newClient.ImportContactsCsv( ContactModelList );
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
		public void CheckMessageStatusNotNumer () {
			Client.CheckMessageStatus( "message" );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckMessageStatusBadToken () {
			Client = new Client( "Token" );
			Client.CheckMessageStatus( "73786923" );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckMessageStatusBadNumber () {
			Client.CheckMessageStatus( "1" );
		}

		[TestMethod]
		public void CheckMessageStatusDelivered () {
			Assert.AreEqual( "Delivered", Client.CheckMessageStatus( "73786923" ) );
		}

		[TestMethod]
		public void CheckMessageStatusUndeliverable () {
			Assert.AreEqual( "Undeliverable", Client.CheckMessageStatus( "73959607" ) );
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
		public void CheckEmptyGroupBadToken () {
			Client = new Client( "Token" );
			Client.EmptyGroup( "group1" );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckEmptyGroupBadName () {
			Client.EmptyGroup( "somegroup" );
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