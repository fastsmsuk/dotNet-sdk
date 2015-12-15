using System;
using System.Collections.Generic;
using System.Configuration;
using FastSms.Enums;
using FastSms.Exceptions;
using FastSms.Extensions;
using FastSms.Models.Requests;
using FastSms.Models.Responses;
using FastSms.Remote;

namespace FastSms {
	public class FastSmsClient : IFastSmsClient {
        public const string ApiUrl = "https://my.fastsms.co.uk/api?Token=";

        private readonly string _token;
	    private readonly IHttpClient _httpClient;

		public FastSmsClient () {
			_token = ConfigurationManager.AppSettings["FastSmsToken"];
            _httpClient = new HttpClient();
		}

		public FastSmsClient ( string token ) {
			_token = token;
            _httpClient = new HttpClient();
        }

        public FastSmsClient(string token, IHttpClient httpClient)
        {
            _token = token;
            _httpClient = httpClient;
        }

        /// <summary>
        ///    Checks your current credit balance. No further parameters are required.
        ///    Your credit balance will be returned in the content of the page.
        /// </summary>
        /// <returns>Credit balance.</returns>
        public decimal CheckCredits () {
			var requestUrl = string.Format( "{0}{1}&Action=CheckCredits", ApiUrl, _token );

			var response = _httpClient.GetResponse( requestUrl ).Replace( ",", "." );

			var credits = response.AsDecimalSafe();
			if (credits <= 0m ) {
				throw new FastSmsException( response );
			}
			return credits ?? 0m;
		}

        /// <summary>
        ///    Checks message status.
        /// </summary>
        /// <param name="messageId">The Message ID of the message that you wish to query.  This is the ID returned by the Send action and can also be found in a message report</param>
        /// <returns>Message status.</returns>
        public string CheckMessageStatus ( string messageId ) {
			var requestUrl = string.Format( "{0}{1}&Action=CheckMessageStatus&MessageID={2}", ApiUrl, _token, messageId );

			var messageStatus = _httpClient.GetResponse( requestUrl );

			if ( FastSmsErrors.Errors.Keys.Contains( messageStatus ) ) {
				throw new FastSmsException( messageStatus );
			}

			return messageStatus;
		}

		/// <summary>
		///    Transfers credits to/from a child user.
		/// </summary>
		/// <param name="childUsername">Child username</param>
		/// <param name="quantity">Quantity of credits</param>
		public void UpdateCredits ( string childUsername, int quantity ) {
			var requestUrl = string.Format( "{0}{1}&Action=UpdateCredits&ChildUsername={2}&Quantity={3}", ApiUrl, _token, childUsername, quantity );

			var result = _httpClient.GetResponse( requestUrl );

			if ( result.AsIntSafe() != 1 ) {
				throw new FastSmsException( result );
			}
		}

		/// <summary>
		///    Deletes all contacts in current account.
		/// </summary>
		public void DeleteAllContacts () {
			var requestUrl = string.Format( "{0}{1}&Action=DeleteAllContacts", ApiUrl, _token );

			var result = _httpClient.GetResponse( requestUrl );

			if ( result.AsIntSafe() != 1 ) {
				throw new FastSmsException( result );
			}
		}

        /// <summary>
        ///    Deletes all groups.
        /// </summary>
        public void DeleteAllGroups () {
			var requestUrl = string.Format( "{0}{1}&Action=DeleteAllGroups", ApiUrl, _token );

			var result = _httpClient.GetResponse( requestUrl );

			if ( result.AsIntSafe() != 1 ) {
				throw new FastSmsException( result );
			}
		}

		/// <summary>
		///    Removes all contacts from the specified group.
		/// </summary>
		/// <param name="groupName">Group name to empty</param>
		public void EmptyGroup ( string groupName ) {
			var requestUrl = string.Format( "{0}{1}&Action=EmptyGroup&Group={2}", ApiUrl, _token, groupName );

			var result = _httpClient.GetResponse( requestUrl );

			if ( result.AsIntSafe() != 1 ) {
				throw new FastSmsException( result );
			}
		}

		/// <summary>
		///    Deletes the specified group.
		/// </summary>
		/// <param name="groupName">Group name to delete</param>
		public void DeleteGroup ( string groupName ) {
			var requestUrl = string.Format( "{0}{1}&Action=DeleteGroup&Group={2}", ApiUrl, _token, groupName );

			var result = _httpClient.GetResponse( requestUrl );

			if ( result.AsIntSafe() != 1 ) {
				throw new FastSmsException( result );
			}
		}

		/// <summary>
		///    Creates the user.
		/// </summary>
		/// <param name="user">User model to create</param>
		public void CreateUser ( CreateUserRequest user ) {
			var requestUrl = string.Format( "{0}{1}&Action=CreateUser&ChildUsername={2}&ChildPassword={3}&AccessLevel={4}&FirstName={5}" +
			                                "&LastName={6}&Email={7}&Credits={8}&CreditReminder={9}&Alert={10}&Telephone={11}",
				ApiUrl, _token, user.ChildUsername, user.ChildPassword, user.AccessLevel,
				user.FirstName, user.LastName, user.Email, user.Credits, user.CreditReminder, user.Alert, user.Telephone );

			var result = _httpClient.GetResponse( requestUrl );

			if ( result.AsIntSafe() != 1 ) {
				throw new FastSmsException( result );
			}
		}

        /// <summary>
        ///    Sends a message. The message ID or error code will be returned in the content of the Page. 
        ///    If multiple numbers are submitted, then multiple IDs / error codes will be returned, separated by commas.
        /// </summary>
        /// <param name="messageToUser">Message model</param>
        /// <returns>Id of sent message.</returns>
        public string SendMessage ( SendMessageToUserRequest messageToUser ) {
			var requestUrl = string.Format( "{0}{1}&Action=Send&DestinationAddress={2}&SourceAddress={3}&Body={4}&ScheduleDate={5}&SourceTON={6}&ValidityPeriod={7}" +
			                                "&GetAllMessageIDs={8}&GetBGSendID{9}",
				ApiUrl, _token, messageToUser.DestinationAddress, messageToUser.SourceAddress, messageToUser.Body,
				messageToUser.ScheduleDate, messageToUser.SourceTon, messageToUser.ValidityPeriod, messageToUser.GetAllMessageIDs,
				messageToUser.GetBgSendId );

			var messageId = _httpClient.GetResponse( requestUrl );

			if ( FastSmsErrors.Errors.Keys.Contains( messageId ) ) {
				throw new FastSmsException( messageId );
			}

			return messageId;
		}

		/// <summary>
		///    Sends message to group.
		/// </summary>
		/// <param name="messageToGroup">Message model for group</param>
		public void SendMessage ( MessageToGroupRequest messageToGroup ) {
			var requestUrl = string.Format( "{0}{1}&Action=Send&DestinationAddress=Group&GroupName={2}&SourceAddress={3}&Body={4}&ScheduleDate={5}&SourceTON={6}&ValidityPeriod={7}" +
			                                "&GetAllMessageIDs={8}&GetBGSendID{9}",
				ApiUrl, _token, messageToGroup.GroupName, messageToGroup.SourceAddress, messageToGroup.Body,
				messageToGroup.ScheduleDate, messageToGroup.SourceTon, messageToGroup.ValidityPeriod, messageToGroup.GetAllMessageIDs,
				messageToGroup.GetBgSendId );

			var result = _httpClient.GetResponse( requestUrl );

			if ( result.AsIntSafe() < 1 ) {
				throw new FastSmsException( result );
			}
		}

		/// <summary>
		///    Sends message to list.
		/// </summary>
		/// <param name="messageToList">Message model for list</param>
		public void SendMessage ( SendMessageToListRequest messageToList ) {
			var requestUrl = string.Format( "{0}{1}&Action=Send&DestinationAddress=List&ListName={2}&SourceAddress={3}&Body={4}&ScheduleDate={5}&SourceTON={6}&ValidityPeriod={7}" +
			                                "&GetAllMessageIDs={8}&GetBGSendID={9}",
				ApiUrl, _token, messageToList.ListName, messageToList.SourceAddress, messageToList.Body,
				messageToList.ScheduleDate, messageToList.SourceTon, messageToList.ValidityPeriod, messageToList.GetAllMessageIDs,
				messageToList.GetBgSendId );

			var result = _httpClient.GetResponse( requestUrl );

			if ( result.AsIntSafe() < 1 ) {
				throw new FastSmsException( result );
			}
		}

        /// <summary>
        ///    Retrieve the data from a report. The report, in CSV format, will be returned in the content of the page.
        /// </summary>
        /// <param name="reportType">The Type of report. Options are: Outbox (From and To dates are ignored for this report), Messages, Usage, Inbound messages</param>
        /// <param name="dateFrom">The start date for the report (YYYYMMDDHHMMSS)</param>
        /// <param name="dateTo">The end date for the report (YYYYMMDDHHMMSS)</param>
        /// <returns>List of messages in report.</returns>
        public List<BaseReportResponse> GetReports ( ReportType reportType, string dateFrom, string dateTo ) {
			var requestUrl = string.Format( "{0}{1}&Action=Report&ReportType={2}&From={3}&To={4}", ApiUrl, _token, reportType,
				dateFrom, dateTo );

			var response = _httpClient.GetResponse( requestUrl );

			int error;
			var hasError = int.TryParse( response, out error );

			if ( hasError && error < 1 ) {
				throw new FastSmsException( response );
			}

			List<BaseReportResponse> report;

			switch ( reportType ) {
				case ReportType.Messages: {
					report = ReportParser.GetMessageReport( response );
					break;
				}
				case ReportType.Outbox: {
					report = ReportParser.GetOuboxReport( response );
					break;
				}
				case ReportType.InboundMessages: {
					report = ReportParser.GetInboundReport( response );
					break;
				}
				case ReportType.Usage: {
					report = ReportParser.GetUsageReport( response );
					break;
				}
				default:
					throw new FastSmsException( response );
			}
			return report;
		}

		/// <summary>
		///    Imports contacts in the address book.
		/// </summary>
		/// <param name="contacts">Contact list</param>
		/// <param name="ignoreDupes">Allow duplicate contacts</param>
		/// <param name="overwriteDupesOne">Ignore dupes</param>
		/// <param name="overwriteDupesTwo">Overwrite duplicate number</param>
		/// <returns>Result of import.</returns>
		public List<ImportStatusResponse> ImportContactsCsv ( List<ImportContactsRequest> contacts, bool ignoreDupes = false, bool overwriteDupesOne = false, bool overwriteDupesTwo = false ) {
			var resultList = new List<ImportStatusResponse>();
			var messageNumber = 1;
			foreach ( var contact in contacts ) {
				var urlForGroups = string.Empty;

				if ( !string.IsNullOrEmpty( contact.Group1 ) ) {
					urlForGroups = string.Format( ",{0}", contact.Group1 );
				}
				if ( !string.IsNullOrEmpty( contact.Group2 ) ) {
					urlForGroups = string.Format( "{0},{1}", urlForGroups, contact.Group2 );
				}
				if ( !string.IsNullOrEmpty( contact.Group3 ) ) {
					urlForGroups = string.Format( "{0},{1}", urlForGroups, contact.Group3 );
				}

				var requestUrl = string.Format( "{0}{1}&Action=ImportContactsCSV&ContactsCSV={2},{3},{4}{5}&IgnoreDupes={6}&OverwriteDupes={7}&OverwriteDupes={8}",
					ApiUrl, _token, contact.Name, contact.Number, contact.Email, urlForGroups, ignoreDupes ? 1 : 0, overwriteDupesOne ? 1 : 0, overwriteDupesTwo ? 1 : 0 );

				var response = _httpClient.GetResponse( requestUrl );

				int error;
				var hasError = int.TryParse( response, out error );
				if ( hasError && error < 1 ) {
					throw new FastSmsException( response );
				}

				var resultStatus = response.Split( '\n' )[0].Split( ':' )[1].Replace( "\n", string.Empty ).Replace( " ", string.Empty );
				resultList.Add( new ImportStatusResponse {
					Number = messageNumber++,
					Status = resultStatus
				} );
			}
			return resultList;
		}

        //This method is not implemented in API yet.
        /// <summary>
        ///    Returns a JSON array of MessageID/Number/Status objects 
        ///    (e.g. [{“MessageID”:”3509592″,”Destination”:”447777777777″,”Status”:”Sent”},
        ///           {“MessageID”:”3509593″,”Destination”:”447777777778″,”Status”:”Sent”}]
        ///    or a json error array as follows: {“error”:”-521″,”message”:”Unknown Background SendID”}
        /// </summary>
        /// <param name="bgSendId">ID of the send you want to retrieve messages for</param>
        /// <returns>List of background messages.</returns>
        //public List<MessageResponse> GetBgMessages(string bgSendId)
        //{
        //    var requestUrl = string.Format("{0}{1}&Action=GetBGMessages&BGSendID={2}", ApiUrl, _token, bgSendId);

        //    var response = _httpClient.GetResponse(requestUrl);

        //    try
        //    {
        //        //var lisOfMessages = JsonConvert.DeserializeObject<List<MessageResponse>>(response);
        //        //return lisOfMessages;
        //    }
        //    catch (Exception)
        //    {
        //        //var error = JsonConvert.DeserializeObject<ErrorMessageResponse>(response);
        //        //throw new ApiException(error.Number);
        //    }

        //    return null;
        //}
    }
}