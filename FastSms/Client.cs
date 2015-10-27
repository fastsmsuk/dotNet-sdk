using System;
using System.Configuration;
using FastSms.Common;
using FastSms.Exceptions;
using FastSms.Models;
using System.Collections.Generic;
using System.Linq;

namespace FastSms
{
    public class Client
    {
        private readonly string _token;

        public Client()
        {
            _token = ConfigurationManager.AppSettings["Token"];
        }

        public Client(string token)
        {
            _token = token;
        }

        /// <summary>
        ///    Checks current credit balance.
        /// </summary>
        /// <returns>Credit balance.</returns>
        public double CheckCredits()
        {
            var requestUrl = string.Format("{0}{1}&Action=CheckCredits", Constants.ApiUrl, _token);

            var credits = HttpClientHelper.GetResponse(requestUrl);

            return Convert.ToDouble(credits);
        }

        /// <summary>
        ///    Checks message status.
        /// </summary>
        /// <param name="messageId">Message ID</param>
        /// <returns>Message status.</returns>
        public string CheckMessageStatus(string messageId)
        {
            var requestUrl = string.Format("{0}{1}&Action=CheckMessageStatus&MessageID={2}", Constants.ApiUrl, _token, messageId);

            var messageStatus = HttpClientHelper.GetResponse(requestUrl);

            return messageStatus;
        }

        /// <summary>
        ///    Transfers credits to/from a child user.
        /// </summary>
        /// <param name="childUsername">Child username</param>
        /// <param name="quantity">Quantity of credits</param>
        public void UpdateCredits(string childUsername, int quantity)
        {
            var requestUrl = string.Format("{0}{1}&Action=UpdateCredits&ChildUsername={2}&Quantity={3}", Constants.ApiUrl, _token, childUsername, quantity);

            var result = HttpClientHelper.GetResponse(requestUrl);

            if (Convert.ToInt32(result) != 1)
            {
                throw new ApiException();
            }
        }

        /// <summary>
        ///    Deletes all contacts in current account.
        /// </summary>
        public void DeleteAllContacts()
        {
            var requestUrl = string.Format("{0}{1}&Action=DeleteAllContacts", Constants.ApiUrl, _token);

            var result = HttpClientHelper.GetResponse(requestUrl);

            if (Convert.ToInt32(result) != 1)
            {
                throw new ApiException();
            }
        }

        /// <summary>
        ///    Deletes all groups.
        /// </summary>
        public void DeleteAllGroups()
        {
            var requestUrl = string.Format("{0}{1}&Action=DeleteAllGroups", Constants.ApiUrl, _token);

            var result = HttpClientHelper.GetResponse(requestUrl);

            if (Convert.ToInt32(result) != 1)
            {
                throw new ApiException();
            }
        }

        /// <summary>
        ///    Removes all contacts from the specified group.
        /// </summary>
        /// <param name="groupName">Group name to empty</param>
        public void EmptyGroup(string groupName)
        {
            var requestUrl = string.Format("{0}{1}&Action=EmptyGroup&Group={2}", Constants.ApiUrl, _token, groupName);

            var result = HttpClientHelper.GetResponse(requestUrl);

            if (Convert.ToInt32(result) != 1)
            {
                throw new ApiException();
            }
        }

        /// <summary>
        ///    Deletes the specified group.
        /// </summary>
        /// <param name="groupName">Group name to delete</param>
        public void DeleteGroup(string groupName)
        {
            var requestUrl = string.Format("{0}{1}&Action=DeleteGroup&Group={2}", Constants.ApiUrl, _token, groupName);

            var result = HttpClientHelper.GetResponse(requestUrl);

            if (Convert.ToInt32(result) != 1)
            {
                throw new ApiException();
            }
        }

        /// <summary>
        ///    Creates the user.
        /// </summary>
        /// <param name="user">User model to create</param>
        public void CreateUser(UserModel user)
        {
            var requestUrl = string.Format("{0}{1}&Action=CreateUser&ChildUsername={2}&ChildPassword={3}&AccessLevel={4}&FirstName={5}" +
                                            "&LastName={6}&Email={7}&Credits={8}&CreditReminder={9}&Alert={10}&Telephone={11}",
                Constants.ApiUrl, _token, user.ChildUsername, user.ChildPassword, user.AccessLevel,
                user.FirstName, user.LastName, user.Email, user.Credits, user.CreditReminder, user.Alert, user.Telephone);

            var result = HttpClientHelper.GetResponse(requestUrl);

            if (Convert.ToInt32(result) != 1)
            {
                throw new ApiException();
            }
        }

        public List<ReportModel> GetReports(ReportType reportType, string dateFrom, string dateTo)
        {
            var requestUrl = string.Format("{0}{1}&Action=Report&ReportType={2}&From={3}&To={4}", Constants.ApiUrl, _token, reportType.ToString(),
                dateFrom, dateTo);


            var response = HttpClientHelper.GetResponse(requestUrl);

            int error;
            bool hasError = int.TryParse(response, out error);

            if (hasError)
            {
                if (error < 1)
                {
                    throw new ApiException(response);
                }
            }

            switch (reportType)
            {
                case ReportType.Messages: return MessageReport(response);
                case ReportType.Outbox: return OuboxReport(response);
                case ReportType.InboundMessages: return InboundReport(response);
                case ReportType.Usage: return UsageReport(response);
                default: throw new ApiException(response);
            }
        }

        public List<string> ImportContactsCSV(List<ContactsCSVModel> contacts, string ignoreDupes = "", string overwriteDupesOne = "", string overwriteDupesTwo = "")
        {
            List<string> result = new List<string>();
            foreach (var model in contacts)
            {
                string requestUrl = "";
                var currUrl = string.Format("{0}{1}&Action=ImportContactsCSV&ContactsCSV={2},{3},{4}", Constants.ApiUrl, _token, model.Name, model.Number, model.Email);
                if (!String.IsNullOrEmpty(model.Group1))
                {
                    requestUrl = string.Format("{0},{1}", currUrl, model.Group1);
                    currUrl = requestUrl;
                }
                if (!string.IsNullOrEmpty(model.Group2))
                {
                    requestUrl = string.Format("{0},{1}", currUrl, model.Group2);
                    currUrl = requestUrl;
                }
                if (!string.IsNullOrEmpty(model.Group3))
                {
                    requestUrl = string.Format("{0},{1}", currUrl, model.Group3);
                    currUrl = requestUrl;
                }
                if (!string.IsNullOrEmpty(ignoreDupes))
                {
                    requestUrl = string.Format("{0}&IgnoreDupes={1}", currUrl, ignoreDupes);
                    currUrl = requestUrl;
                }
                if (!string.IsNullOrEmpty(overwriteDupesOne))
                {
                    requestUrl = string.Format("{0}&OverwriteDupes={1}", currUrl, overwriteDupesOne);
                    currUrl = requestUrl;
                }
                if (!string.IsNullOrEmpty(overwriteDupesTwo))
                {
                    requestUrl = string.Format("{0}OverwriteDupes={1}", currUrl, overwriteDupesTwo);
                    currUrl = requestUrl;
                }
                var response = HttpClientHelper.GetResponse(requestUrl);
                int error;

                bool hasError = int.TryParse(response, out error);
                if (hasError)
                {
                    if (error < 1)
                    {
                        throw new ApiException(response);
                    }
                }

                result.Add(response.Split(':')[1].Replace("\n", string.Empty));

            }
            return result;

        }


        private List<ReportModel> MessageReport(string response)
        {
            var responseList = response.Split('\n');

            List<ReportModel> reportResult = new List<ReportModel>();


            for (int i = 1; i < responseList.Length; i++)
            {
                MessageReportModel messageReport = new MessageReportModel();
                string[] currentList = responseList[i].Split(',');
                if (responseList[i] != "")
                {
                    messageReport.MessageID = currentList[0].Replace("\"", string.Empty);
                    messageReport.Username = currentList[1].Replace("\"", string.Empty);
                    messageReport.Destination = currentList[2].Replace("\"", string.Empty);
                    messageReport.Source = currentList[3].Replace("\"", string.Empty);
                    messageReport.Status = currentList[4].Replace("\"", string.Empty);
                    messageReport.ScheduleDate = currentList[5].Replace("\"", string.Empty);
                    messageReport.SentDate = currentList[6].Replace("\"", string.Empty);
                    messageReport.DeliveryDate = currentList[7].Replace("\"", string.Empty);
                    reportResult.Add(messageReport);
                }
            }
            return reportResult;
        }

        private List<ReportModel> OuboxReport(string response)
        {
            var responseList = response.Split('\n');

            List<ReportModel> reportResult = new List<ReportModel>();

            for (int i = 1; i < responseList.Length; i++)
            {
                OutboxReportModel outboxReport = new OutboxReportModel();
                string[] currentList = responseList[i].Split(',');
                if (responseList[i] != "")
                {
                    outboxReport.MessageID = currentList[0].Replace("\"", string.Empty);
                    outboxReport.Username = currentList[1].Replace("\"", string.Empty);
                    outboxReport.Destination = currentList[2].Replace("\"", string.Empty);
                    outboxReport.Status = currentList[3].Replace("\"", string.Empty);
                    outboxReport.ScheduleDate = currentList[4].Replace("\"", string.Empty);
                    outboxReport.SentDate = currentList[5].Replace("\"", string.Empty);
                    outboxReport.DeliveryDate = currentList[6].Replace("\"", string.Empty);

                    reportResult.Add(outboxReport);
                }
            }

            return reportResult;
        }

        private List<ReportModel> UsageReport(string response)
        {
            var responseList = response.Split('\n');

            List<ReportModel> reportResult = new List<ReportModel>();


            for (int i = 1; i < responseList.Length; i++)
            {
                UsageReportModel usageReport = new UsageReportModel();
                string[] currentList = responseList[i].Split(',');
                if (responseList[i] != "")
                {
                    usageReport.Status = currentList[0].Replace("\"", string.Empty);
                    usageReport.Messages = currentList[1].Replace("\"", string.Empty);

                    reportResult.Add(usageReport);
                }
            }
            return reportResult;
        }

        private List<ReportModel> InboundReport(string response)
        {
            var responseList = response.Split('\n');

            List<ReportModel> reportResult = new List<ReportModel>();


            for (int i = 1; i < responseList.Length; i++)
            {
                InboundMessagesReportModel inboundReport = new InboundMessagesReportModel();
                string[] currentList = responseList[i].Split(',');
                if (responseList[i] != "")
                {
                    inboundReport.MessageID = currentList[0].Replace("\"", string.Empty);
                    inboundReport.From = currentList[1].Replace("\"", string.Empty);
                    inboundReport.Number = currentList[2].Replace("\"", string.Empty);
                    inboundReport.Message = currentList[3].Replace("\"", string.Empty);
                    inboundReport.ReceivedDate = currentList[4].Replace("\"", string.Empty);
                    inboundReport.Status = currentList[5].Replace("\"", string.Empty);

                    reportResult.Add(inboundReport);
                }
            }
            return reportResult;
        }
    }
}