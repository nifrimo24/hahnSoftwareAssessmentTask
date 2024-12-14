using Application;
using Application.Companies.Create;
using Application.JobVacancies.Create;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.API;
using Web.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation()
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast");

#region CompanyEndpoints

app.MapPost("/companies", async (ISender mediator, [FromBody] CreateCompanyCommand command) =>
{
    var createResult = await mediator.Send(command);
    return Results.Ok(createResult);
});

#endregion CompanyEndpoints

#region JobVacancyEndpoints

app.MapPost("/job-vacancies", async (ISender mediator, [FromBody] CreateJobVacancyCommand command) =>
{
    var createResult = await mediator.Send(command);
    return Results.Ok(createResult);
});

#endregion JobVacancyEndpoints

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}