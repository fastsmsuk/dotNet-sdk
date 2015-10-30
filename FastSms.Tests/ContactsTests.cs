using System.Collections.Generic;
using FastSms.Exceptions;
using FastSms.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastSms.Tests {
	[TestClass]
	public class ContactsTests {
		public Client Client;
		public List<ContactsCSVModel> ContactModelList;
		public List<ImportStatusModel> ImportContactsCsvResults;

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
		}

		[TestMethod]
		public void CheckImportContactsCsvSuccess () {
			Assert.AreEqual( "Success", ImportContactsCsvResults[0].Status, "Status must be Success" );
		}

		[TestMethod]
		public void CheckImportContactsCsvNoName () {
			Assert.AreEqual( "Failed", ImportContactsCsvResults[2].Status, "Status must be Failed" );
		}

		[TestMethod]
		public void CheckImportContactsCsvNoNumber () {
			Assert.AreEqual( "Failed", ImportContactsCsvResults[3].Status, "Status must be Failed" );
		}

		[TestMethod]
		public void CheckImportContactsCsvDuplicateName () {
			Assert.AreEqual( "DuplicateName", ImportContactsCsvResults[6].Status, "Status must be DuplicateName" );
		}

		[TestMethod]
		public void CheckImportContactsCsvDuplicateNumber () {
			Assert.AreEqual( "DuplicateNumber", ImportContactsCsvResults[7].Status, "Status must be DuplicateName" );
		}

		[TestMethod]
		public void CheckImportContactsCsvWithIgnoreDupes () {
			Client.DeleteAllContacts();
			ImportContactsCsvResults = Client.ImportContactsCsv( ContactModelList, 1 );
			Assert.AreEqual( "Success", ImportContactsCsvResults[6].Status, "Status must be Success" );
		}

		[TestMethod]
		public void CheckImportContactsCsvBadNumber () {
			Assert.AreEqual( "Failed", ImportContactsCsvResults[4].Status, "Status must be Failed" );
		}

		[TestMethod]
		[ExpectedException ( typeof ( ApiException ) )]
		public void CheckImportContactsCsvBadToken () {
			var newClient = new Client( "Token" );
			newClient.ImportContactsCsv( ContactModelList );
		}
	}
}