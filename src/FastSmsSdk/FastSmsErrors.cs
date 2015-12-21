using System.Collections.Generic;
using FastSms.Localization;

namespace FastSms {
	public static class FastSmsErrors {
		public static readonly IDictionary<string, string> Errors = new Dictionary<string, string> {
			{"-100", Resources.NotEnoughCredits},
			{"-101", Resources.InvalidCreditId},
			{"-200", Resources.InvalidContact},
			{"-300", Resources.GeneralDatabaseError},
			{"-301", Resources.UnknownError},
			{"-302", Resources.ReturnXmlError},
			{"-303", Resources.ReceivedXmlError},
			{"-400", Resources.SomeNumbersInListFailed},
			{"-401", Resources.InvalidDestinationAddress},
			{"-402", Resources.AlphanumericTooLong},
			{"-403", Resources.InvalidNumber},
			{"-404", Resources.BlankBody},
			{"-405", Resources.InvalidValidityPeriod},
			{"-406", Resources.NoRouteAvailable},
			{"-407", Resources.InvalidScheduleDate},
			{"-408", Resources.DistributionListIsEmpty},
			{"-409", Resources.GroupIsEmpty},
			{"-410", Resources.InvalidDistributionList},
			{"-411", Resources.SingleNumber},
			{"-412", Resources.NumberIsBlacklisted},
			{"-414", Resources.InvalidGroup},
			{"-501", Resources.UnknownUsernamePassword},
			{"-502", Resources.UnknownAction},
			{"-503", Resources.UnknownMessageID},
			{"-504", Resources.InvalidFromTimestamp},
			{"-505", Resources.InvalidToTimestamp},
			{"-506", Resources.SourceAddressNotAllowed},
			{"-507", Resources.InvalidMissingDetails},
			{"-508", Resources.ErrorCreatingUser},
			{"-509", Resources.UnknownInvalidUser},
			{"-510", Resources.UsersCredits},
			{"-511", Resources.IsDownForMaintenance},
			{"-512", Resources.UserSuspended},
			{"-513", Resources.LicenseInUse},
			{"-514", Resources.LicenseExpired},
			{"-515", Resources.NoLicenseAvailable},
			{"-516", Resources.UnknownList},
			{"-517", Resources.UnableToCreateList},
			{"-518", Resources.BlankOrInvalidSourceAddress},
			{"-519", Resources.BlankMessageBody},
			{"-520", Resources.UnknownGroup},
			{"-601", Resources.UnknownReportType},
			{"-701", Resources.NoUserIDSpecified},
			{"-702", Resources.InvalidAmountSpecified},
			{"-703", Resources.InvalidCurrencyRequested}
		};
	}
}