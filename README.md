# zerobounce-dotnet-api
This is a .Net wrapper class example for the ZeroBounce API.
The ValidateEmail and GetCredit methods return objects from which you can retrieve properties that return the relevant information.<br>
<br>
<b>Example usage:<br></b>
var zeroBounceAPI = new ZeroBounce.ZeroBounceAPI();<br>
// set input parameters;<br>
zeroBounceAPI.apiKey =  "Your API Key";<br>
zeroBounceAPI.emailToValidate = "Your Email Address";      <br> 
zeroBounceAPI.ipAddress = "Your IP address";<br>
zeroBounceAPI.readTimeOut = 200000;// "Any integer value in milliseconds;<br>
zeroBounceAPI.requestTimeOut = 150000; // "Any integer value in milliseconds;<br>

// validate email and assign results to an object<br>
var apiProperties = zeroBounceAPI.ValidateEmail();<br>
// check credits and assign results to an object<br>
var apiCredits= zeroBounceAPI.GetCredits();
