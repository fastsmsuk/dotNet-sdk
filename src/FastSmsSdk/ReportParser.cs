using System.Collections.Generic;
using FastSmsSdk.Models.Responses;
using FastSmsSdk.Extensions;

namespace FastSmsSdk {
	internal static class ReportParser {
		/// <summary>
		///    Gets inbound messages.
		/// </summary>
		/// <param name="response">Response from API</param>
		/// <returns>List of messages.</returns>
		public static List<BaseReportResponse> GetInboundReport ( string response ) {
			var responseList = response.Split( '\n' );

			var reportResult = new List<BaseReportResponse>();

			for ( var index = 1; index < responseList.Length; index++ ) {
				var inboundReport = new InboundMessagesReportResponse();
				var currentList = responseList[index].Split( ',' );
				if ( !string.IsNullOrEmpty( responseList[index] ) ) {
					inboundReport.MessageId = currentList.ReplaceForIndex(0);
					inboundReport.From = currentList.ReplaceForIndex(1);
                    inboundReport.Number = currentList.ReplaceForIndex(2);
                    inboundReport.Message = currentList.ReplaceForIndex(3);
                    inboundReport.ReceivedDate = currentList.ReplaceForIndex(4);
                    inboundReport.Status = currentList.ReplaceForIndex(5);

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
		public static List<BaseReportResponse> GetUsageReport ( string response ) {
			var responseList = response.Split( '\n' );

			var reportResult = new List<BaseReportResponse>();

			for ( var index = 1; index < responseList.Length; index++ ) {
				var usageReport = new UsageReportResponse();
				var currentList = responseList[index].Split( ',' );
				if ( !string.IsNullOrEmpty( responseList[index] ) ) {
					usageReport.Status = currentList.ReplaceForIndex(0);
                    usageReport.Messages = currentList.ReplaceForIndex(1);

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
		public static List<BaseReportResponse> GetOuboxReport ( string response ) {
			var responseList = response.Split( '\n' );

			var reportResult = new List<BaseReportResponse>();

			for ( var index = 1; index < responseList.Length; index++ ) {
				var outboxReport = new OutboxReportResponse();
				var currentList = responseList[index].Split( ',' );
				if ( !string.IsNullOrEmpty( responseList[index] ) ) {
					outboxReport.MessageId = currentList.ReplaceForIndex(0);
                    outboxReport.Username = currentList.ReplaceForIndex(1);
                    outboxReport.Destination = currentList.ReplaceForIndex(2);
                    outboxReport.Status = currentList.ReplaceForIndex(3);
                    outboxReport.ScheduleDate = currentList.ReplaceForIndex(4);
                    outboxReport.SentDate = currentList.ReplaceForIndex(5);
                    outboxReport.DeliveryDate = currentList.ReplaceForIndex(6);

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
		public static List<BaseReportResponse> GetMessageReport ( string response ) {
			var responseList = response.Split( '\n' );

			var reportResult = new List<BaseReportResponse>();

			for ( var index = 1; index < responseList.Length; index++ ) {
				var messageReport = new MessageReportResponse();
				var currentList = responseList[index].Split( ',' );
				if ( !string.IsNullOrEmpty( responseList[index] ) ) {
					messageReport.MessageId = currentList.ReplaceForIndex(0);
                    messageReport.Username = currentList.ReplaceForIndex(1);
                    messageReport.Destination = currentList.ReplaceForIndex(2);
                    messageReport.Source = currentList.ReplaceForIndex(3);
                    messageReport.Status = currentList.ReplaceForIndex(4);
                    messageReport.ScheduleDate = currentList.ReplaceForIndex(5);
                    messageReport.SentDate = currentList.ReplaceForIndex(6);
                    messageReport.DeliveryDate = currentList.ReplaceForIndex(7);
                    reportResult.Add( messageReport );
				}
			}
			return reportResult;
		}
	}
}