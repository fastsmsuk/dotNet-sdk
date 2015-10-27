using System.Collections.Generic;
using FastSms.Models;

namespace FastSms.Common {
	public static class ReportHelper {
		/// <summary>
		///    Gets inbound messages.
		/// </summary>
		/// <param name="response">Response from API</param>
		/// <returns>List of messages.</returns>
		public static List<ReportModel> GetInboundReport ( string response ) {
			var responseList = response.Split( '\n' );

			var reportResult = new List<ReportModel>();

			for ( var index = 1; index < responseList.Length; index++ ) {
				var inboundReport = new InboundMessagesReportModel();
				var currentList = responseList[index].Split( ',' );
				if ( !string.IsNullOrEmpty( responseList[index] ) ) {
					inboundReport.MessageID = currentList[0].Replace( "\"", string.Empty );
					inboundReport.From = currentList[1].Replace( "\"", string.Empty );
					inboundReport.Number = currentList[2].Replace( "\"", string.Empty );
					inboundReport.Message = currentList[3].Replace( "\"", string.Empty );
					inboundReport.ReceivedDate = currentList[4].Replace( "\"", string.Empty );
					inboundReport.Status = currentList[5].Replace( "\"", string.Empty );

					reportResult.Add( inboundReport );
				}
			}
			return reportResult;
		}

		/// <summary>
		///    Gets usage report.
		/// </summary>
		/// <param name="response">Response from API</param>
		/// <returns>List of messages.</returns>
		public static List<ReportModel> GetUsageReport ( string response ) {
			var responseList = response.Split( '\n' );

			var reportResult = new List<ReportModel>();

			for ( var index = 1; index < responseList.Length; index++ ) {
				var usageReport = new UsageReportModel();
				var currentList = responseList[index].Split( ',' );
				if ( !string.IsNullOrEmpty( responseList[index] ) ) {
					usageReport.Status = currentList[0].Replace( "\"", string.Empty );
					usageReport.Messages = currentList[1].Replace( "\"", string.Empty );

					reportResult.Add( usageReport );
				}
			}
			return reportResult;
		}

		/// <summary>
		///    Gets outbox report.
		/// </summary>
		/// <param name="response">Response from API</param>
		/// <returns>List of messages.</returns>
		public static List<ReportModel> GetOuboxReport ( string response ) {
			var responseList = response.Split( '\n' );

			var reportResult = new List<ReportModel>();

			for ( var index = 1; index < responseList.Length; index++ ) {
				var outboxReport = new OutboxReportModel();
				var currentList = responseList[index].Split( ',' );
				if ( !string.IsNullOrEmpty( responseList[index] ) ) {
					outboxReport.MessageID = currentList[0].Replace( "\"", string.Empty );
					outboxReport.Username = currentList[1].Replace( "\"", string.Empty );
					outboxReport.Destination = currentList[2].Replace( "\"", string.Empty );
					outboxReport.Status = currentList[3].Replace( "\"", string.Empty );
					outboxReport.ScheduleDate = currentList[4].Replace( "\"", string.Empty );
					outboxReport.SentDate = currentList[5].Replace( "\"", string.Empty );
					outboxReport.DeliveryDate = currentList[6].Replace( "\"", string.Empty );

					reportResult.Add( outboxReport );
				}
			}

			return reportResult;
		}

		/// <summary>
		///    Gets message report.
		/// </summary>
		/// <param name="response">Response from API</param>
		/// <returns>List of messages.</returns>
		public static List<ReportModel> GetMessageReport ( string response ) {
			var responseList = response.Split( '\n' );

			var reportResult = new List<ReportModel>();

			for ( var index = 1; index < responseList.Length; index++ ) {
				var messageReport = new MessageReportModel();
				var currentList = responseList[index].Split( ',' );
				if ( !string.IsNullOrEmpty( responseList[index] ) ) {
					messageReport.MessageID = currentList[0].Replace( "\"", string.Empty );
					messageReport.Username = currentList[1].Replace( "\"", string.Empty );
					messageReport.Destination = currentList[2].Replace( "\"", string.Empty );
					messageReport.Source = currentList[3].Replace( "\"", string.Empty );
					messageReport.Status = currentList[4].Replace( "\"", string.Empty );
					messageReport.ScheduleDate = currentList[5].Replace( "\"", string.Empty );
					messageReport.SentDate = currentList[6].Replace( "\"", string.Empty );
					messageReport.DeliveryDate = currentList[7].Replace( "\"", string.Empty );
					reportResult.Add( messageReport );
				}
			}
			return reportResult;
		}
	}
}