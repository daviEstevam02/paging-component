using EasyDocs.WebApi.Configurations;
using EasyDocs.WebApi.Configurations.Swagger;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuring Database
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// Configuring JWT
builder.Services.AddJwtConfiguration();

// Configuring Dependency Injection
builder.Services.AddDependencyInjectionConfiguration();

// Configuring Swagger
builder.Services.AddSwaggerConfiguration();

// Configuring AutoMapper
builder.Services.AddAutoMapperConfiguration();

// Adding MediatR for Domain Events and Notifications
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseCors(x =>
{
    x.AllowAnyHeader();
    x.AllowAnyMethod();
    x.AllowAnyOrigin();
});

app.UseSwaggerSetup();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();