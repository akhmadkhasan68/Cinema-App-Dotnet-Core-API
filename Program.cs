using System.Net.Http.Headers;
using CinemaApp;
using CinemaApp.Infrastructures.Database;
using CinemaApp.Interfaces;
using CinemaApp.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Services to The Container
new AppProvider(builder).ConfigureServices();

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
