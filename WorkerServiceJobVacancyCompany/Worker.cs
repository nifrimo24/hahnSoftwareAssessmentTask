using Microsoft.Extensions.Hosting;
using WorkerServiceJobVacancyCompany.Application.Services;

public class Worker : BackgroundService
{
    private readonly UpsertJobVacancyCompanyService _upsertJobVacancyCompanyService;

    public Worker(UpsertJobVacancyCompanyService upsertJobVacancyCompanyService)
    {
        _upsertJobVacancyCompanyService = upsertJobVacancyCompanyService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _upsertJobVacancyCompanyService.FetchAndUpsertJob();
            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
        }
    }

    public static async Task FetchAndUpsertJob(IServiceProvider services)
    {
        var upsertJobVacancyCompanyService = services.GetRequiredService<UpsertJobVacancyCompanyService>();
        await upsertJobVacancyCompanyService.FetchAndUpsertJob();
    }
}