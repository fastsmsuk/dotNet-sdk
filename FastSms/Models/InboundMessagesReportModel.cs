namespace FastSms.Models
{
    public class InboundMessagesReportModel : ReportModel
    {
        public string MessageID { get; set; }
        public string From { get; set; }
        public string Number { get; set; }
        public string Message { get; set; }
        public string ReceivedDate { get; set; }
        public string Status { get; set; }
    }
}
