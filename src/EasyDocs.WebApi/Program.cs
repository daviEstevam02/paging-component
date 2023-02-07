using EasyDocs.WebApi.Configurations;
using Gooders.Services.WebApi.Configuration.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuring Database
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// Configuring JWT
builder.Services.AddJwtConfiguration();

// Configuring Swagger
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseSwaggerSetup();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();