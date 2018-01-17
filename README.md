# zerobounce-dotnet-api
This is a .Net wrapper class example for the ZeroBounce API.<br>
The <b><i>ValidateEmail</b></i> and <b><i>GetCredit</b></i> methods return objects from which you can retrieve properties that return the relevant information.<br>
<br>
<b>Example usage:<br></b>
```C#
var zeroBounceAPI = new ZeroBounce.ZeroBounceAPI();

//set input parameters

zeroBounceAPI.apiKey = "Your API Key";
zeroBounceAPI.emailToValidate = "Your Email Address";
zeroBounceAPI.ipAddress = "Your IP address";
zeroBounceAPI.readTimeOut = 200000;// "Any integer value in milliseconds
zeroBounceAPI.requestTimeOut = 150000; // "Any integer value in milliseconds

// validate email and assign results to an object
var apiProperties = zeroBounceAPI.ValidateEmail();
// check credits and assign results to an object
var apiCredits= zeroBounceAPI.GetCredits();
```
