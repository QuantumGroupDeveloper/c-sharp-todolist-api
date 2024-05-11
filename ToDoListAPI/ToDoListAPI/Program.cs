using Microsoft.EntityFrameworkCore;
// using ToDoListAPI.Infrastracture.DB.SQLServer;
using ToDoListAPI.Infrastracture.DB.MySQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQLServer
// builder.Services.AddDbContext<TodolistContext>(option => option.UseSqlServer("Name=ConnectionStrings:sqlserver"));

// MySQL
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();
string connectionString = config["ConnectionStrings:mysql"];
builder.Services.AddDbContext<TodolistContext>(option => option.UseMySQL(connectionString));

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
