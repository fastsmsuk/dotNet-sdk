using System;
using System.Configuration;
using FastSms.Common;
using FastSms.Exceptions;
using FastSms.Models;

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

			var credits = HttpClientHelper.GetResponse( requestUrl );

			return Convert.ToDouble( credits );
		}

		/// <summary>
		///    Checks message status.
		/// </summary>
		/// <param name="messageId">Message ID</param>
		/// <returns>Message status.</returns>
		public string CheckMessageStatus ( string messageId ) {
			var requestUrl = string.Format( "{0}{1}&Action=CheckMessageStatus&MessageID={2}", Constants.ApiUrl, _token, messageId );

			var messageStatus = HttpClientHelper.GetResponse( requestUrl );

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
	}
}