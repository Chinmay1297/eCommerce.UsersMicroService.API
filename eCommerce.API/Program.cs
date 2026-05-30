using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Add Infrastructure services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add controllers to the service collection
builder.Services.AddControllers()
        .AddJsonOptions((options) =>        
        {
            //You need to add this to convert enum values to string in the JSON request. Otherwise, the API will expect integer values for enum properties in the request body, and result in error.
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

//Build the web application
var app = builder.Build();

app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();

app.Run();
