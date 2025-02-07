using DAL.DbEngineerContext;
using Microsoft.EntityFrameworkCore;
using Shared.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the .
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder
            .WithOrigins("http://localhost:4200") // The URL of the Angular app
            .AllowAnyMethod()
            .AllowAnyHeader());

});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.ConfigureServices((hostContext, services) =>
{
    ServicesConfig.RegisterDb(services, hostContext.Configuration.GetConnectionString("SQLServer"));
});

//Need to reg the db context
ServicesConfig.Register(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
