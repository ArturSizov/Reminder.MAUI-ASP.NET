using Reminder.API;
using Reminder.API.Services;
using Reminder.Contracts.DataAccessLayer.Context;
using Reminder.Contracts.DataAccessLayer.Implementations;
using Reminder.Contracts.DataAccessLayer.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add services
builder.Services.AddSingleton<IDataProvider>(new DataProvider(Helper.GetDatabasePath("Reminder.sqlite.db")));
builder.Services.AddSingleton<IPersonData, PersonData>();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureApi();

app.Run();
