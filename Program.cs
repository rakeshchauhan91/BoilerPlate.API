
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;
using BoilerPlate.API;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using Serilog;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
     .Enrich.WithThreadId()
     .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();


if (logger.IsEnabled(Serilog.Events.LogEventLevel.Information))
    logger.Information("Starting API");

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

builder.Services.ConfigureOptions<ApisettingConfigureOptions>();

builder.Services.AddFeatureManagement()
    .AddFeatureFilter<TimeWindowFilter>();

builder.Services.AddHealthChecks()
               .AddSqlServer(builder.Configuration.GetConnectionString("MsSqlDb"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
