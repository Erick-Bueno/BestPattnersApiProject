using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using projetassocavalo.Api.Errors;
using projetassocavalo.Application;
using projetassocavalo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCors();

builder.Services.AddSingleton<ProblemDetailsFactory, ProjetassoCavaloProblemDetailsFactory>();

var app = builder.Build();

app.UseCors(c =>
{
    c.AllowCredentials();
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.WithOrigins("http://localhost:4200");

});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseExceptionHandler("/error");

app.MapControllers();

app.Run();
