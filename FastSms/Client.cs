using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using FastSms.Common;
using FastSms.Exceptions;
using FastSms.Models;
using Newtonsoft.Json;

namespace FastSms {
	public class Client {
		private readonly string _token;

		public Client () {
			_token = ConfigurationManager.AppSettings["Token"];
		}

		public Client ( string token ) {
			_token = token;
		}

		/// <summary>
		///    Checks current credit balance.
		/// </summary>
		/// <returns>Credit balance.</returns>
		public double CheckCredits () {
			var requestUrl = string.Format( "{0}{1}&Action=CheckCredits", Constants.ApiUrl, _token );

			var response = HttpClientHelper.GetResponse( requestUrl );

			var credits = Convert.ToDouble( response );

			if ( credits <= 0 ) {
				throw new ApiException( response );
			}
			return credits;
		}

		/// <summary>
		///    Checks message status.
		/// </summary>
		/// <param name="messageId">Message ID</param>
		/// <returns>Message status.</returns>
		public string CheckMessageStatus ( string messageId ) {
			var requestUrl = string.Format( "{0}{1}&Action=CheckMessageStatus&MessageID={2}", Constants.ApiUrl, _token, messageId );

			var messageStatus = HttpClientHelper.GetResponse( requestUrl );

			if ( Constants.ErrorList.Keys.Contains( messageStatus ) ) {
				throw new ApiException();
			}

			return messageStatus;
		}

		/// <summary>
		///    Transfers credits to/from a child user.
		/// </summary>
		/// <param name="childUsername">Child username</param>
		/// <param name="quantity">Quantity of credits</param>
		public void UpdateCredits ( string childUsername, int quantity ) {
			var requestUrl = string.Format( "{0}{1}&Action=UpdateCredits&ChildUsername={2}&Quantity={3}", Constants.ApiUrl, _token, childUsername, quantity );

			var result = HttpClientHelper.GetResponse( requestUrl );

			if ( Convert.ToInt32( result ) != 1 ) {
				throw new ApiException();
			}
		}

		/// <summary>
		///    Deletes all contacts in current account.
		/// </summary>
		public void DeleteAllContacts () {
			var requestUrl = string.Format( "{0}{1}&Action=DeleteAllContacts", Constants.ApiUrl, _token );

			var result = HttpClientHelper.GetResponse( requestUrl );

			if ( Convert.ToInt32( result ) != 1 ) {
				throw new ApiException();
			}
		}

		/// <summary>
		///    Deletes all groups.
		/// </summary>
		public void DeleteAllGroups () {
			var requestUrl = string.Format( "{0}{1}&Action=DeleteAllGroups", Constants.ApiUrl, _token );

			var result = HttpClientHelper.GetResponse( requestUrl );

			if ( Convert.ToInt32( result ) != 1 ) {
				throw new ApiException();
			}
		}

		/// <summary>
		///    Removes all contacts from the specified group.
		/// </summary>
		/// <param name="groupName">Group name to empty</param>
		public void EmptyGroup ( string groupName ) {
			var requestUrl = string.Format( "{0}{1}&Action=EmptyGroup&Group={2}", Constants.ApiUrl, _token, groupName );

			var result = HttpClientHelper.GetResponse( requestUrl );

			if ( Convert.ToInt32( result ) != 1 ) {
				throw new ApiException();
			}
		}

		/// <summary>
		///    Deletes the specified group.
		/// </summary>
		/// <param name="groupName">Group name to delete</param>
		public void DeleteGroup ( string groupName ) {
			var requestUrl = string.Format( "{0}{1}&Action=DeleteGroup&Group={2}", Constants.ApiUrl, _token, groupName );

			var result = HttpClientHelper.GetResponse( requestUrl );

			if ( Convert.ToInt32( result ) != 1 ) {
				throw new ApiException();
			}
		}

		/// <summary>
		///    Creates the user.
		/// </summary>
		/// <param name="user">User model to create</param>
		public void CreateUser ( UserModel user ) {
			var requestUrl = string.Format( "{0}{1}&Action=CreateUser&ChildUsername={2}&ChildPassword={3}&AccessLevel={4}&FirstName={5}" +
			                                "&LastName={6}&Email={7}&Credits={8}&CreditReminder={9}&Alert={10}&Telephone={11}",
				Constants.ApiUrl, _token, user.ChildUsername, user.ChildPassword, user.AccessLevel,
				user.FirstName, user.LastName, user.Email, user.Credits, user.CreditReminder, user.Alert, user.Telephone );

			var result = HttpClientHelper.GetResponse( requestUrl );

			if ( Convert.ToInt32( result ) != 1 ) {
				throw new ApiException();
			}
		}

		/// <summary>
		///    Sends message to user/users.
		/// </summary>
		/// <param name="messageToUser">Message model</param>
		/// <returns>Id of sent message.</returns>
		public string SendMessage ( MessageToUserModel messageToUser ) {
			var requestUrl = string.Format( "{0}{1}&Action=Send&DestinationAddress={2}&SourceAddress={3}&Body={4}&ScheduleDate={5}&SourceTON={6}&ValidityPeriod={7}" +
			                                "&GetAllMessageIDs={8}&GetBGSendID{9}",
				Constants.ApiUrl, _token, messageToUser.DestinationAddress, messageToUser.SourceAddress, messageToUser.Body,
				messageToUser.ScheduleDate, messageToUser.SourceTon, messageToUser.ValidityPeriod, messageToUser.GetAllMessageIDs,
				messageToUser.GetBgSendId );

			var messageId = HttpClientHelper.GetResponse( requestUrl );

			if ( Constants.ErrorList.Keys.Contains( messageId ) ) {
				throw new ApiException();
			}

			return messageId;
		}

		/// <summary>
		///    Sends message to group.
		/// </summary>
		/// <param name="messageToGroup">Message model for group</param>
		public void SendMessage ( MessageToGroupModel messageToGroup ) {
			var requestUrl = string.Format( "{0}{1}&Action=Send&DestinationAddress=Group&GroupName={2}&SourceAddress={3}&Body={4}&ScheduleDate={5}&SourceTON={6}&ValidityPeriod={7}" +
			                                "&GetAllMessageIDs={8}&GetBGSendID{9}",
				Constants.ApiUrl, _token, messageToGroup.GroupName, messageToGroup.SourceAddress, messageToGroup.Body,
				messageToGroup.ScheduleDate, messageToGroup.SourceTon, messageToGroup.ValidityPeriod, messageToGroup.GetAllMessageIDs,
				messageToGroup.GetBgSendId );

			var result = HttpClientHelper.GetResponse( requestUrl );

			if ( Convert.ToInt32( result ) < 1 ) {
				throw new ApiException();
			}
		}

		/// <summary>
		///    Sends message to list.
		/// </summary>
		/// <param name="messageToList">Message model for list</param>
		public void SendMessage ( MessageToListModel messageToList ) {
			var requestUrl = string.Format( "{0}{1}&Action=Send&DestinationAddress=List&ListName={2}&SourceAddress={3}&Body={4}&ScheduleDate={5}&SourceTON={6}&ValidityPeriod={7}" +
			                                "&GetAllMessageIDs={8}&GetBGSendID={9}",
				Constants.ApiUrl, _token, messageToList.ListName, messageToList.SourceAddress, messageToList.Body,
				messageToList.ScheduleDate, messageToList.SourceTon, messageToList.ValidityPeriod, messageToList.GetAllMessageIDs,
				messageToList.GetBgSendId );

			var result = HttpClientHelper.GetResponse( requestUrl );

			if ( Convert.ToInt32( result ) < 1 ) {
				throw new ApiException();
			}
		}

		/// <summary>
		///    Gets background messages.
		/// </summary>
		/// <param name="bgSendId">Background send ID</param>
		/// <returns>List of background messages.</returns>
		public List<MessageModel> GetBgMessages ( string bgSendId ) {
			var requestUrl = string.Format( "{0}{1}&Action=GetBGMessages&BGSendID={2}", Constants.ApiUrl, _token, bgSendId );

			var response = HttpClientHelper.GetResponse( requestUrl );

			var lisOfMessages = JsonConvert.DeserializeObject<List<MessageModel>>( response );

			return lisOfMessages;
		}
   }
}