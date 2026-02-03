using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shahmati.Application.Games;
using Shahmati.Contracts;
using Shahmati.Infrastructure.Postgres;
using Shahmati.Web;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddProgrammCollection(builder.Configuration);


var app = builder.Build();

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "noviyAsp"));

}

app.MapControllers();

app.Run();