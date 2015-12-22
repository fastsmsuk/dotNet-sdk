using System;
using System.Linq;
using FastSmsSdk;
using FastSmsSdk.Enums;
using FastSmsSdk.Exceptions;
using FastSmsSdk.Models.Requests;
using FastSmsSdk.Models.Responses;

namespace FastSmsExample
{
    internal class Program
    {
        private const string ArgumentError = @"Argument error";
        private const string Success = @"Success";

        private static void Main(string[] args)
        {
            try
            {
                CompileCommand(args);
            }
            catch (FastSmsException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void CompileCommand(string[] args)
        {
            var client = new FastSmsClient("6Rx6-stiU-a8sY-vt9i");
            var commandArguments = args;
            if (!commandArguments.Any())
                return;
            var command = commandArguments[0];

            switch (command)
            {
                case "CheckCredits":
                    Console.WriteLine(client.CheckCredits());
                    break;
                case "CheckMessageStatus":
                    if (commandArguments.Length != 2)
                        Console.WriteLine(ArgumentError);
                    else
                        Console.WriteLine(client.CheckMessageStatus(commandArguments[1]));
                    break;
                case "UpdateCredits":
                    int i;
                    if (commandArguments.Length != 3 || !int.TryParse(commandArguments[2], out i))
                        Console.WriteLine(ArgumentError);
                    else
                    {
                        client.UpdateCredits(commandArguments[1], i);
                        Console.WriteLine(Success);
                    }
                    break;
                case "DeleteAllContacts":
                    if (commandArguments.Length != 1)
                        Console.WriteLine(ArgumentError);
                    else
                    {
                        client.DeleteAllContacts();
                        Console.WriteLine(Success);
                    }
                    break;
                case "DeleteAllGroups":
                    if (commandArguments.Length != 1)
                        Console.WriteLine(ArgumentError);
                    else
                    {
                        client.DeleteAllGroups();
                        Console.WriteLine(Success);
                    }
                    break;
                case "EmptyGroup":
                    if (commandArguments.Length != 2)
                        Console.WriteLine(ArgumentError);
                    else
                    {
                        client.EmptyGroup(commandArguments[1]);
                        Console.WriteLine(Success);
                    }
                    break;
                case "DeleteGroup":
                    if (commandArguments.Length != 2)
                        Console.WriteLine(ArgumentError);
                    else
                    {
                        client.DeleteGroup(commandArguments[1]);
                        Console.WriteLine(Success);
                    }
                    break;
                case "CreateUser":
                    if (commandArguments.Length != 3)
                    {
                        Console.WriteLine(ArgumentError);
                    }
                    else
                    {
                        var user = new CreateUserRequest(commandArguments[1], commandArguments[2])
                        {
                            LastName = "User Last name",
                            AccessLevel = "Normal",
                            ChildPassword = "Password",
                            Email = @"email@example.com",
                            Credits = 100
                        };
                        client.CreateUser(user);
                        Console.WriteLine(Success);
                    }
                    break;
                case "SendMessageToUser":
                    if (commandArguments.Length != 3)
                    {
                        Console.WriteLine(ArgumentError);
                    }
                    else
                    {
                        var message = new SendMessageToUserRequest()
                        {
                            Body = commandArguments[1],
                            DestinationAddress = commandArguments[2]
                        };
                        client.SendMessage(message);
                        Console.WriteLine(Success);
                    }
                    break;
                case "SendMessageToGroup":
                    if (commandArguments.Length != 3)
                    {
                        Console.WriteLine(ArgumentError);
                    }
                    else
                    {
                        var message = new MessageToGroupRequest()
                        {
                            Body = commandArguments[1],
                            GroupName = commandArguments[2]
                        };
                        client.SendMessage(message);
                        Console.WriteLine(Success);
                    }
                    break;
                case "SendMessageToList":
                    if (commandArguments.Length != 3)
                    {
                        Console.WriteLine(ArgumentError);
                    }
                    else
                    {
                        var message = new SendMessageToListRequest()
                        {
                            Body = commandArguments[1],
                            ListName = commandArguments[2]
                        };
                        client.SendMessage(message);
                        Console.WriteLine(Success);
                    }
                    break;
                case "GetReports":
                    if (commandArguments.Length != 4)
                    {
                        Console.WriteLine(ArgumentError);
                    }
                    else
                    {
                        var reportType = ReportType.Messages;
                        switch (commandArguments[1])
                        {
                            case "InboundMessages":
                                reportType = ReportType.InboundMessages;
                                break;
                            case "Messages":
                                reportType = ReportType.Messages;
                                break;
                            case "Outbox":
                                reportType = ReportType.Outbox;
                                break;
                            case "Usage":
                                reportType = ReportType.Usage;
                                break;
                        }
                        var reports = client.GetReports(reportType, commandArguments[2], commandArguments[3]);
                        foreach (var report in reports)
                        {
                            Console.WriteLine(ReportToString(report));
                        }
                    }
                    break;
                case "Help":
                    Help();
                    break;
                default:
                    break;
            }
        }


        private static void Help()
        {
            Console.WriteLine("CheckCredits\t\tChecks your current credit balance. No further parameters are required. Your credit balance will be returned in the content of the page.");
            Console.WriteLine();
            Console.WriteLine("CheckMessageStatus\tChecks message status\nparam: messageId");
            Console.WriteLine();
            Console.WriteLine("UpdateCredits\t\tTransfers credits to/from a child user\nparam: childUsername quantity");
            Console.WriteLine();
            Console.WriteLine("DeleteAllContacts\tDeletes all contacts in current account.");
            Console.WriteLine();
            Console.WriteLine("DeleteAllGroups\t\tDeletes all groups");
            Console.WriteLine();
            Console.WriteLine("EmptyGroup\t\tRemoves all contacts from the specified group.\nparam: groupName");
            Console.WriteLine();
            Console.WriteLine("DeleteGroup\t\tDeletes the specified group.\nparam: groupName");
            Console.WriteLine();
            Console.WriteLine("CreateUser\t\tCreates the user.\nparam: userName telephone");
            Console.WriteLine();
            Console.WriteLine("SendMessageToUser\t Sends a message. The message ID or error code will be returned in the content of the Page.If multiple numbers are submitted, then multiple IDs / error codes will be returned, separated by commas.\nparam: Body DestinationAddress");
            Console.WriteLine();
            Console.WriteLine("SendMessageToGroup\tSends message to group.\nparam: Body GroupName");
            Console.WriteLine();
            Console.WriteLine("SendMessageToList\t Sends message to list.\nparam: Body ListName");
            Console.WriteLine();
            Console.WriteLine("GetReports\t\t Retrieve the data from a report. The report, in CSV format, will be returned in the content of the page.\nparam: reportType dateFrom dateTo");
            Console.WriteLine();
        }

        private static string ReportToString(BaseReportResponse report)
        {
            if (report is InboundMessagesReportResponse)
            {
                var typedReport = (InboundMessagesReportResponse)report;
                return string.Format("{0} {1} {2} {3} {4} {5}", typedReport.Message, typedReport.From, typedReport.MessageId, typedReport.Number, typedReport.ReceivedDate, typedReport.Status);
            }
            if (report is UsageReportResponse)
            {
                var typedReport = (UsageReportResponse)report;
                return string.Format("{0} {1}", typedReport.Status, typedReport.Messages);
            }
            if (report is OutboxReportResponse)
            {
                var typedReport = (OutboxReportResponse)report;
                return string.Format("{0} {1} {2} {3} {4} {5} {6}", typedReport.Status, typedReport.MessageId, typedReport.DeliveryDate, typedReport.Destination, typedReport.ScheduleDate, typedReport.SentDate, typedReport.Username);
            }
            if (report is MessageReportResponse)
            {
                var typedReport = (MessageReportResponse)report;
                return string.Format("{0} {1} {2} {3} {4} {5} {6} {7}", typedReport.Status, typedReport.MessageId, typedReport.DeliveryDate, typedReport.Destination, typedReport.ScheduleDate, typedReport.SentDate, typedReport.Username, typedReport.Source);
            }
            return string.Empty;
        }
    }
}



