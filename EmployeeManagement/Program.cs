using ApplicationServices.Services;

using DataAccess.Common;
using DataAccess.IConfiguration;

using DataLayer.SqlServer.Repositories;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("EmployeeConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));

//Adding the unit of work to DI container
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//We can use DI Tools such as Castel, ...
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<EmployeeRepository, EmployeeRepository>();

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
