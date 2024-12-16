using Application;
using Application.Companies.Create;
using Application.Companies.Update;
using Application.JobVacancies.Create;
using Application.JobVacancies.Update;
using Application.JobVacancies.Upsert;
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

#region CompanyEndpoints

app.MapPost("/companies", async (ISender mediator, [FromBody] CreateCompanyCommand command) =>
{
    var createResult = await mediator.Send(command);
    return Results.Ok(createResult);
});

app.MapPut("/companies", async (ISender mediator, [FromBody] UpdateCompanyCommand command) =>
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

app.MapPut("/job-vacancies", async (ISender mediator, [FromBody] UpdateJobVacancyCommand command) =>
{
    var createResult = await mediator.Send(command);
    return Results.Ok(createResult);
});

#endregion JobVacancyEndpoints

#region UpsertEndpoints

app.MapPost("/upsert", async (ISender mediator, [FromBody] UpsertJobVacanciesCompaniesCommand command) =>
{
    var createResult = await mediator.Send(command);
    return Results.Ok(createResult);
});

#endregion UpsertEndpoints

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}