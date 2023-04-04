using DiziCashier.Application.Handlers.CommandHandler;
using DiziCashier.Core.Command;
using DiziCashier.Core.Command.Base;
using DiziCashier.Core.Query.Base;
using DiziCashier.Infrastructure.Data;
using DiziCashier.Infrastructure.Repositories.Command;
using DiziCashier.Infrastructure.Repositories.Command.Base;
using DiziCashier.Infrastructure.Repositories.Query.Base;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DiziDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DiziCashier")));
builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateItemCategoryCommandHandler).GetTypeInfo().Assembly));
//builder.Services.AddHandlers(typeof(IRequestHandler<,>), typeof(Program));

//builder.Services.AddMediatR(typeof(CreateItemCategoryCommandHandler).GetTypeInfo().Assembly);
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
//builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
builder.Services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
builder.Services.AddTransient<IItemCategoryCommandRepository, ItemCategoryCommandRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
