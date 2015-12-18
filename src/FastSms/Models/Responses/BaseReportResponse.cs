using FastSms.Enums;

namespace FastSms.Models.Responses {
    /// <summary>
    ///    Base model for reports
    /// </summary>
    public abstract class BaseReportResponse {
        /// <summary>
        ///    The Type of report. Options are: Outbox, Messages, Usage, Inbound messages.
        /// </summary>
        public ReportType ReportType { get; set; }
    }
}