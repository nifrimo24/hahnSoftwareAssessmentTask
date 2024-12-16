using System.Net.Http.Json;
using Newtonsoft.Json;
using WorkerServiceJobVacancyCompany.Application.Common;
using WorkerServiceJobVacancyCompany.Domain.DTOs;

namespace WorkerServiceJobVacancyCompany.Application.Services;

public class UpsertJobVacancyCompanyService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public UpsertJobVacancyCompanyService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task FetchAndUpsertJob()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetStringAsync("https://jobicy.com/api/v2/remote-jobs?count=50&geo=latam");
        var apiResponse = JsonConvert.DeserializeObject<JobVacancyCompanyDTO>(response);

        var vacancies = apiResponse.Jobs;
        var createdAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        var jobVacancyCompanyApiRequest = vacancies.Select(v => new JobVacancyCompany(
            v.Id,
            v.AnnualSalaryMax ?? 0,
            v.AnnualSalaryMin ?? 0,
            v.CompanyLogo,
            v.CompanyName,
            createdAt,
            v.SalaryCurrency ?? "",
            v.JobDescription,
            v.JobExcerpt,
            v.JobGeo,
            v.JobIndustry.FirstOrDefault() ?? "",
            v.JobLevel,
            v.PubDate,
            v.JobTitle,
            v.JobType.FirstOrDefault() ?? "",
            v.Url
        )).ToList();
        
        var bodyRequest = new JobVacancyCompanyAPIRequest(jobVacancyCompanyApiRequest);
        var upsertResponse = await client.PostAsJsonAsync("http://localhost:5191/upsert", bodyRequest);

        var status = upsertResponse.IsSuccessStatusCode;
        var statusCode = upsertResponse.StatusCode;
        
        var date = DateTime.Now.ToString("yyyy-MM-dd");
        var time = DateTime.Now.ToString("HHmmss");
        
        var fileName = $"UPSERT_{date}_{time}_STATUS_{statusCode}_{status}.json";
        var filePath = Path.Combine(@"D:\JobVacancyCompany_Upsert", fileName);
        
        var msg = await upsertResponse.Content.ReadAsStringAsync();
        var jsonObject = new
        {
            Message = msg
        };
        
        await File.WriteAllTextAsync(filePath, JsonConvert.SerializeObject(jsonObject));
    }
}