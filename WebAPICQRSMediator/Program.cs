using CQRS.Handlers;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment.EnvironmentName;

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Default file
    .AddJsonFile("appsettings.{env}.json", optional: true, reloadOnChange: true) // Development-specific settings
    .AddEnvironmentVariables(); // Load environment variables if needed

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssemblies([typeof(Program).Assembly,
    typeof(CQRS.Handlers.GetCustomersQueryHandler).Assembly]);
});

// Register FluentValidation with MVC
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddValidatorsFromAssemblyContaining<CreateCustomerCommandValidator>();

builder.Services.AddControllers();
// Register Swagger services.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Melvis API",
        Description = "An Mel API for demo purposes",
        Version = "v1"
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.Run();
