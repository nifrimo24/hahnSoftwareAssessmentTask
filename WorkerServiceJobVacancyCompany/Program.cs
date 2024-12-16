using Hangfire;
using Hangfire.SqlServer;
using WorkerServiceJobVacancyCompany;
using WorkerServiceJobVacancyCompany.Application.Services;
using Newtonsoft.Json;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddSingleton<UpsertJobVacancyCompanyService>();

builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseSerializerSettings(new JsonSerializerSettings
    {
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    })
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("SqlServer"), new SqlServerStorageOptions
    {
        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        QueuePollInterval = TimeSpan.Zero,
        UseRecommendedIsolationLevel = true,
        DisableGlobalLocks = true
    }));

builder.Services.AddHangfireServer();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();

using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var recurringJobManager = services.GetRequiredService<IRecurringJobManager>();

    recurringJobManager.AddOrUpdate("FetchAndUpsertJob", () => Worker.FetchAndUpsertJob(services), "*/5 * * * *");
}

host.Run();