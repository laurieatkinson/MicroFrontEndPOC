# MicroFrontEndPOC
Demo using ASP.NET Core MVC for a micro frontend.
Visual Studio solution includes 5 ASP.NET Core Web Apps - Container plus 4 apps each hosted separately.

![img](https://repository-images.githubusercontent.com/296737497/63b80080-f9c8-11ea-973b-ec66ebba770a)

## Key Features
### Container.UI
1. wwwroot/css/site.css - <em>Global CSS shared by all apps</em>
2. wwwroot/js/site.js - <em>Loads each of the 4 apps</em>
### WebApp1.UI
1. wwwroot/css/site.css - <em>Styles for this app only and uses a selector to scope them correctly. Note: SASS would make this less error prone.</em>
2. wwwroot/js/site.js - <em>Example that subscribes to a global event using JavaScript</em>
3. appsettings.json - <em>One option for storing the location of the deployed app</em>
```json
  "rootUrl": "http://localhost:8001",
  "containerUrl": "http://localhost:8000"
```
4. Startup.cs - <em>Enable CORS to allow cross-domain requests to this app</em>
```csharp
services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy",
            builder => builder.WithOrigins(Configuration["containerUrl"])
                .WithMethods("GET", "POST")
                .AllowAnyHeader());
    });
. . .
app.UseCors("CorsPolicy");
```
5. Controllers/HomeController.cs - <em>Index returns View with Layout. Other pages return PartialView.</em>
6. Views/Home/Index.cshtml, Page2.cshtml, Page3.cshtml - <em>Example of AJAX link using jquery.unobtrusive-ajax library and using url of this app in the link</em>
```html
@using Microsoft.Extensions.Configuration
@inject IConfiguration Configuration
@{
    string rootUrl = Configuration["rootUrl"];
}
<a data-ajax="true" data-ajax-url="@rootUrl/home/page2"
   data-ajax-update="#webapp1 #content"
   data-ajax-loading="#webapp1 #spinner">Next Page</a>
```    
### WebApp3.UI
1. wwwroot/js/page1.js and page2.js - <em>Fix an issue with jquery validation and the order that the page is loaded</em>
```javascript
$.validator.unobtrusive.parse("#page1-form form");
```
2. Views/Home/Index.cshtml, Page2.cshtml - <em>Example of AJAX form using jquery.unobtrusive-ajax library along with jquery validation</em>
```html
<form method="POST" data-ajax="true" data-ajax-url="@rootUrl" data-ajax-update="#webapp3 #content">
    First Name: <input asp-for="FirstName" /> <br />
    <span asp-validation-for="FirstName" class="text-danger"></span> <br />
    Last Name: <input asp-for="LastName" /> <br />
    <span asp-validation-for="LastName" class="text-danger"></span> <br />
    <hr />
    <button id="submitButton" type="submit">Save</button>
</form>
```
### WebApp4.UI
1. wwwroot/js/page2.js - <em>Example that broadcasts a global event using JavaScript</em>
