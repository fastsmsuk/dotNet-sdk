.NET SDK for FastSMS API.
===========================
.NET library to access [FastSMS](http://www.fastsms.co.uk/) api.
Thank you for choosing [FastSMS](http://www.fastsms.co.uk/)<br/>
DIRECTORY STRUCTURE
-------------------

```
FastSms/                 core wrapper code
FastSms.Tests/           tests of the core wrapper code
```

REQUIREMENTS
------------

The minimum requirement by FastSMS wrapper is that your Visual Studio supported .Net Framework 4.5.

DOCUMENTATION
-------------
FastSMS has a [Knowledge Base](http://support.fastsms.co.uk/knowledgebase/) and 
a [Developer Zone](http://support.fastsms.co.uk/knowledgebase/category/developer-zone/) which cover every detail of FastSMS API.

INSTALLATION
-------------

Add reference "FastSms" to your project.

USAGE
=============
Init SDK
-------------
Your token (found in your [settings](https://my.fastsms.co.uk/account/settings) within NetMessenger)
```
var fastSmsClient = new Client('your token');
```

Wrap errors
-------------
List all API codes found in [docs](http://support.fastsms.co.uk/knowledgebase/http-documentation/#ErrorCodes)
```
using FastSms;
...
var fastSmsClient = new Client('Your token');
try {
    var credits = client.CheckCredits();
} catch (ApiException apiException) {
    Console.writeline(apiException.Message, apiException.Code);
} catch (Exception ex) {
    Console.Writeline(ex.Message);
}
```

Actions
-------------
### Credits
Checks your current credit balance.
```
var credits = client.CheckCredits();//returns double value 
```

### Send Message
Sends a message. More information read [here](http://support.fastsms.co.uk/knowledgebase/http-documentation/#SendMessage)
```
...
using FastSms;
using FastSms.Models;
...
// Initialize message for user/users.
var message = new MessageToUserModel {
				DestinationAddress = "Address",
				SourceAddress = "Your source",
				Body = "Message text"
			};
			
// Initialize message for group.	
var message = new MessageToGroupModel {
				GroupName = "Group name",
				SourceAddress = "Your source",
				Body = "Message text"
			};
			
// Initialize message for list.	
var message = new MessageToListModel {
				ListName = "List name",
				SourceAddress = "Your source",
				Body = "Message text"
			};	

client.SendMessage(message);
```

### Check message status
Check send message status. More information read [here](http://support.fastsms.co.uk/knowledgebase/http-documentation/#CheckMessageStatus)
```
var messageStatus = client.CheckMessageStatus(messageId)//message id must be string
```

### Create User
Create new child user. Only possible if you are an admin user. More information read [here](http://support.fastsms.co.uk/knowledgebase/http-documentation/#CreateUser)
```
...
using FastSms;
using FastSms.Models;
...
// Initialize user data
var userData = new UserModel {
				FirstName = "User first name",
				LastName = "User Last name",
				AccessLevel = "Normal",
				ChildPassword = "Password",
				Email = "email@example.com",
				Credits = 100,
				Telephone = "123456789"
			};
client.CreateUser( userData );
```

### Update Credits
Transfer credits to/from a child user. Only possible if you are an admin user. More information read [here](http://support.fastsms.co.uk/knowledgebase/http-documentation/#UpdateCredits)
```
...
using FastSms;
using FastSms.Models;
...
// Initialize update user data
var childUsername = "username";
var quantity = 10;
client.UpdateCredits( childUsername, quantity );
```

### Reports
Retrieve the data from a report. More information read [here](http://support.fastsms.co.uk/knowledgebase/http-documentation/#Reports)
Aviable types:
- ArchivedMessages
- ArchivedMessagesWithBodies
- ArchivedMessagingSummary
- BackgroundSends
- InboundMessages
- KeywordMessageList
- Messages
- MessagesWithBodies
- SendsByDistributionList
- Usage
```
...
using FastSms;
...
// Get report
var report = client.GetReports (reportType, dateFrom, dateTo)//reportType - enumerable, dates - in string 
```

### Add contact(s)
Create contact(s). More information read [here](http://support.fastsms.co.uk/knowledgebase/http-documentation/#ImportContactsCSV)
```
...
using FastSms;
...
// Initialize contacts data
var contacts = new List<ContactsCSVModel> {
				new ContactsCSVModel {
					Name = "Contact name",
					Number = "Contact number"
				},
				new ContactsCSVModel {
					Name = "Contact name",
					Number = "Contact number",
					Group1 = "Contact group"
				},
// Add contacts
var result = client.ImportContactsCsv(contacts);
```

### Delete All Contacts
More information read [here](http://support.fastsms.co.uk/knowledgebase/http-documentation/#DeleteAllContacts)
```
...
using FastSms;
...
client.DeleteAllContacts();
```

### Delete All Groups
More information read [here](http://support.fastsms.co.uk/knowledgebase/http-documentation/#DeleteAllGroups)
```
...
using FastSms;
...
client.DeleteAllGroups();
```

### Empty Group
Remove all contacts from the specified group. More information read [here](http://support.fastsms.co.uk/knowledgebase/http-documentation/#EmptyGroup)
```
...
using FastSms;
...
client.EmptyGroup('Group Name');
```

### Delete Group
Delete the specified group. More information read [here](http://support.fastsms.co.uk/knowledgebase/http-documentation/#DeleteGroup)
```
...
using FastSms;
...
client.DeleteGroup('Group Name');
```

