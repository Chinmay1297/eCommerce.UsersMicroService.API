using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Core.Validators;
using eCommerce.Infrastructure;
using FluentValidation;
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
//Fluent Validation validators will be registered here. This will scan the assembly containing LoginRequestValidator for any classes that inherit from AbstractValidator<T> and register them automatically.
builder.Services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

//This will scan the assembly containing ApplicationUserMappingProfile for AutoMapper profiles and register them automatically.
//You can add more mapping profiles in the same assembly, and they will be registered as well.
builder.Services.AddAutoMapper(cfg => { }, typeof(ApplicationUserMappingProfile).Assembly);

//Add Swagger/OpenAPI services
builder.Services.AddSwaggerGen();

//Build the web application
var app = builder.Build();

app.UseExceptionHandlingMiddleware();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();

app.Run();
