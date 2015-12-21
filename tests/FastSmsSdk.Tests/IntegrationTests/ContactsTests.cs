using System.Collections.Generic;
using FastSms.Exceptions;
using FastSms.Models.Requests;
using FastSms.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastSms.Tests.IntegrationTests {
	[TestClass]
	public class ContactsTests {
		public FastSmsClient Client;
		public List<ImportContactsRequest> ContactModelList;
		public List<ImportStatusResponse> ImportContactsCsvResults;

		[TestInitialize]
		public void TestInitialize () {
			Client = new FastSmsClient();
			Client.DeleteAllContacts();
			ContactModelList = new List<ImportContactsRequest> {
				new ImportContactsRequest {
					Name = "NameZ1111",
					Number = "0984784",
					Group1 = "group1"
				},
				new ImportContactsRequest {
					Name = "NameZ2111",
					Number = "0984724344555842",
					Group1 = "group1_2",
					Group2 = "group2_2",
					Group3 = "group3_3"
				},
				new ImportContactsRequest {
					Name = "",
					Number = "0984734442842",
					Group1 = "group1",
					Group2 = "group2"
				},
				new ImportContactsRequest {
					Name = "NZame3111",
					Number = "",
					Group1 = "group1",
					Group2 = "group2"
				},
				new ImportContactsRequest {
					Name = "NZame4111",
					Number = "somenumber",
					Group1 = "group1",
					Group2 = "group2"
				},
				new ImportContactsRequest {
					Name = "ZName5111",
					Number = "35682258"
				},
				new ImportContactsRequest {
					Name = "NameZ1111",
					Number = "3568234534258",
					Group1 = "group1_6"
				},
				new ImportContactsRequest {
					Name = "Name6111Z",
					Number = "0984784",
					Group1 = "group1_7"
				}
			};

			ImportContactsCsvResults = Client.ImportContactsCsv( ContactModelList );
		}

        [TestMethod]
        [TestCategory("Integration")]
		public void CheckImportContactsCsvSuccess () {
			Assert.AreEqual( "Success", ImportContactsCsvResults[0].Status, "Status must be Success" );
		}

        [TestMethod]
        [TestCategory("Integration")]
		public void CheckImportContactsCsvNoName () {
			Assert.AreEqual( "Failed", ImportContactsCsvResults[2].Status, "Status must be Failed" );
		}

        [TestMethod]
        [TestCategory("Integration")]
		public void CheckImportContactsCsvNoNumber () {
			Assert.AreEqual( "Failed", ImportContactsCsvResults[3].Status, "Status must be Failed" );
		}

        [TestMethod]
        [TestCategory("Integration")]
		public void CheckImportContactsCsvDuplicateName () {
			Assert.AreEqual( "DuplicateName", ImportContactsCsvResults[6].Status, "Status must be DuplicateName" );
		}

        [TestMethod]
        [TestCategory("Integration")]
		public void CheckImportContactsCsvDuplicateNumber () {
			Assert.AreEqual( "DuplicateNumber", ImportContactsCsvResults[7].Status, "Status must be DuplicateName" );
		}

        [TestMethod]
        [TestCategory("Integration")]
		public void CheckImportContactsCsvWithIgnoreDupes () {
			Client.DeleteAllContacts();
			ImportContactsCsvResults = Client.ImportContactsCsv( ContactModelList, true );
			Assert.AreEqual( "Success", ImportContactsCsvResults[6].Status, "Status must be Success" );
		}

        [TestMethod]
        [TestCategory("Integration")]
		public void CheckImportContactsCsvBadNumber () {
			Assert.AreEqual( "Failed", ImportContactsCsvResults[4].Status, "Status must be Failed" );
		}

        [TestMethod]
        [TestCategory("Integration")]
		[ExpectedException ( typeof ( FastSmsException ) )]
		public void CheckImportContactsCsvBadToken () {
			var newClient = new FastSmsClient( "Token" );
			newClient.ImportContactsCsv( ContactModelList );
		}
	}
}