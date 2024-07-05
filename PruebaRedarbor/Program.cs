using log4net.Config;
using log4net;
using System.Text.Json.Serialization;
using PruebaRedarbor.Infrastruture;
using MediatR;
using PruebaRedarbor.Repositories;
using PruebaRedarbor.Domain.Models;
using Autofac.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PruebaRedarbor.Application.Common;

var builder = WebApplication.CreateBuilder(args);

string ASPNETCORE_ENVIRONMENT = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
string connectionString;
string connectionStringMaster;

if (ASPNETCORE_ENVIRONMENT == "Development")
{
    connectionString = builder.Configuration.GetConnectionString("cnPruebaRebardorLocal");
    connectionStringMaster = builder.Configuration.GetConnectionString("cnMasterLocal");
}
else
{
    connectionString = builder.Configuration.GetConnectionString("cnPruebaRebardorDocker");
    connectionStringMaster = builder.Configuration.GetConnectionString("cnMasterDocker");
}


var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

//Add services to the container.

builder.Logging.ClearProviders();
builder.Logging.AddLog4Net("log4net.config");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program).Assembly);

builder.Services.AddSqlServer<PruebaRebardorContext>(connectionString);
builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthConfig.secretKeyJwt));
        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature);

        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = signingKey
        };
    });


builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddScoped<IRepository<Companies>, Repository<Companies>>();
builder.Services.AddScoped<IRepository<Employee>, Repository<Employee>>();
builder.Services.AddScoped<IRepository<Roles>, Repository<Roles>>();
builder.Services.AddScoped<IRepository<Status>, Repository<Status>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }