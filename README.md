# zerobounce-dotnet-api
This is a .Net wrapper class example for the ZeroBounce API.<br><br>
The <b><i>ValidateEmail</b></i> and <b><i>GetCredit</b></i> methods return objects from which you can retrieve properties that return the relevant information.<br>

**Properties and possible values returned by:**
1. <b><i>ValidateEmail</b></i> method
  
|<b>Property</b>|<b>Possible Values</b> 
|:--- |:--- 
address  | The email address you are validating. 
status | Valid /Invalid /Catch-All /Unknown /Spamtrap /Abuse /DoNotMail 
sub-status  |antispam_system /greylisted /mail_server_temporary_error /forcible_disconnect /mail_server_did_not_respond /timeout_exceeded /failed_smtp_connection /mailbox_quota_exceeded /exception_occurred /possible_traps /role_based /global_suppression /mailbox_not_found /no_dns_entries /failed_syntax_check /possible_typo /unroutable_ip_address /leading_period_removed /does_not_accept_mail
account | The portion of the email address before the "@" symbol.
domain | The portion of the email address after the "@" symbol
disposable |[true/false] If the email domain is diposable, which are usually temporary email addresses.
toxic |[true/false] These domains are known for abuse, spam, and bot created.
firstname | The first name of the owner of the email when available or [null].
lastname  |The last name of the owner of the email when available or [null].
gender |The gender of the owner of the email when available or [null].
creation date |The creation date of the email when available or [null].
location|The location of the owner of the email when available or [null].
processedat |The UTC time the email was validated.

2. <b><i>GetCredit</b></i> method
  
|<b>Property</b>|<b>Possible Values</b> 
|:--- |:--- 
credits  | The number of credits left in account for email validation.

**Any of the following email addresses can be used for testing the API, no credits are charged for these test email addresses:**
+ disposable@example.com
+ invalid@example.com
+ valid@example.com
+ toxic@example.com
+ donotmail@example.com
+ spamtrap@example.com
+ abuse@example.com
+ unknown@example.com
+ catch_all@example.com
+ antispam_system@example.com
+ does_not_accept_mail@example.com
+ exception_occurred@example.com
+ failed_smtp_connection@example.com
+ failed_syntax_check@example.com
+ forcible_disconnect@example.com
+ global_suppression@example.com
+ greylisted@example.com
+ leading_period_removed@example.com
+ mail_server_did_not_respond@example.com
+ mail_server_temporary_error@example.com
+ mailbox_quota_exceeded@example.com
+ mailbox_not_found@example.com
+ no_dns_entries@example.com
+ possible_trap@example.com
+ possible_typo@example.com
+ role_based@example.com
+ timeout_exceeded@example.com
+ unroutable_ip_address@example.com

<b>C# Example usage:<br></b>
```C#
 var zeroBounceAPI = new ZeroBounce.ZeroBounceAPI();

//set input parameters
zeroBounceAPI.apiKey = "Your API Key"; //Required
zeroBounceAPI.emailToValidate = "Email address your validating"; //Required
zeroBounceAPI.ipAddress = "IP address the email signed up with"; //Optional
zeroBounceAPI.readTimeOut = 200000;// "Any integer value in milliseconds
zeroBounceAPI.requestTimeOut = 150000; // "Any integer value in milliseconds

//validate email and assign results to an object
var apiProperties = zeroBounceAPI.ValidateEmail();

//check credits and assign results to an object
var apiCredits= zeroBounceAPI.GetCredits();

//use the properties to make decisions on
switch (apiProperties.status)
  {
      case "Invalid":
          Console.WriteLine("Invalid");
          break;
      case "Valid":
          Console.WriteLine("Valid");
          break;
      default:
          Console.WriteLine(apiProperties.status);
          break;
  }
```
<b>VB Example usage:<br></b>

```VB
Dim zeroBounceAPI = New ZeroBounce.ZeroBounceAPI

'set input parameters
zeroBounceAPI.apiKey = "Your API Key" 'Required 
zeroBounceAPI.emailToValidate = "Email address your validating" 'Required
zeroBounceAPI.ipAddress = "IP address the email signed up with" 'Optional
zeroBounceAPI.readTimeOut = 200000 'Any integer value in milliseconds
zeroBounceAPI.requestTimeOut = 150000

Dim apiProperties = zeroBounceAPI.ValidateEmail
Dim apiCredits = zeroBounceAPI.GetCredits

'use the properties to make decisions on
Select Case (apiProperties.status)
    Case "Invalid"
        Console.WriteLine("Invalid")
    Case "Valid"
        Console.WriteLine("Valid")
    Case Else
        Console.WriteLine(apiProperties.status)
End Select
```
