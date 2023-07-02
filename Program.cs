using Microsoft.EntityFrameworkCore;
using MonivetAPI.Models;
using System;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MonivetContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL")));
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var MisReglas = "ReglasCors";
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: MisReglas, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
try
{
    //if (app.Environment.IsDevelopment())
    //{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
    //}

    app.UseCors(MisReglas);

    app.UseRouting();

    app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"Error loading configuration from appsettings.json: {ex.Message}");
    throw;
}
