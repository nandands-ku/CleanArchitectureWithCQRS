using DiziCashier.Application.Handlers.CommandHandler;
using DiziCashier.Application.Interfaces;
using DiziCashier.Core.Command;
using DiziCashier.Core.Command.Base;
using DiziCashier.Core.Query;
using DiziCashier.Core.Query.Base;
using DiziCashier.Infrastructure.Data;
using DiziCashier.Infrastructure.Models;
using DiziCashier.Infrastructure.Persistence;
using DiziCashier.Infrastructure.Repositories.Command;
using DiziCashier.Infrastructure.Repositories.Command.Base;
using DiziCashier.Infrastructure.Repositories.Query;
using DiziCashier.Infrastructure.Repositories.Query.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();
builder.Host.UseSerilog(logger);

builder.Services.AddControllers();
builder.Services.Configure<DiziCashierMongoDatabaseSettings>(
    builder.Configuration.GetSection("DiziCashierMongoDatabase"));

builder.Services.AddDbContext<DiziDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DiziCashier")));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateItemCategoryCommandHandler).GetTypeInfo().Assembly));
builder.Services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
builder.Services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
builder.Services.AddScoped<IItemCategoryCommandRepository, ItemCategoryCommandRepository>();
builder.Services.AddScoped<IItemCategoryQueryRepository, ItemCategoryQueryRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseSerilogRequestLogging();

app.UseAuthorization();

app.MapControllers();

Log.Information("Starting UP!");

try
{
    app.Run();
    Log.Information("Stopped cleanly");

}
catch (Exception ex)
{
    Log.Fatal(ex, "An unhandled exception occured");
}
finally
{
    Log.CloseAndFlush();
}
