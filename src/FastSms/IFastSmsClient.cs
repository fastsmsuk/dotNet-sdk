using System.Collections.Generic;
using FastSms.Enums;
using FastSms.Models.Requests;
using FastSms.Models.Responses;

namespace FastSms
{
    public interface IFastSmsClient
    {
        decimal CheckCredits();
        string CheckMessageStatus(string messageId);
        void UpdateCredits(string childUsername, int quantity);
        void DeleteAllContacts();
        void DeleteAllGroups();
        void EmptyGroup(string groupName);
        void DeleteGroup(string groupName);
        void CreateUser(CreateUserRequest user);
        string SendMessage(SendMessageToUserRequest messageToUser);
        void SendMessage(MessageToGroupRequest messageToGroup);
        void SendMessage(SendMessageToListRequest messageToList);
        List<BaseReportResponse> GetReports(ReportType reportType, string dateFrom, string dateTo);
        List<ImportStatusResponse> ImportContactsCsv(List<ImportContactsRequest> contacts, bool ignoreDupes = false, bool overwriteDupesOne = false, bool overwriteDupesTwo = false);
    }
}
