using Newtonsoft.Json;

namespace WorkerServiceJobVacancyCompany.Application.Common;


public class JobVacancyCompanyAPIRequest
{
    [JsonProperty(nameof(JobVacancyCompanies))]
    public List<JobVacancyCompany> JobVacancyCompanies { get; set; }

    public JobVacancyCompanyAPIRequest(List<JobVacancyCompany> jobVacancyCompanies)
    {
        JobVacancyCompanies = jobVacancyCompanies;
    }
}

public class JobVacancyCompany
{
    [JsonProperty(nameof(ApiId))]
    public int ApiId { get; set; }

    [JsonProperty(nameof(CompanyName))]
    public string CompanyName { get; set; }

    [JsonProperty(nameof(CompanyLogo))]
    public string CompanyLogo { get; set; }

    [JsonProperty(nameof(GeoLocation))]
    public string GeoLocation { get; set; }

    [JsonProperty(nameof(Industry))]
    public string Industry { get; set; }

    [JsonProperty(nameof(AnnualSalaryMax))]
    public int AnnualSalaryMax { get; set; }

    [JsonProperty(nameof(AnnualSalaryMin))]
    public int AnnualSalaryMin { get; set; }

    [JsonProperty(nameof(CreatedAt))]
    public string CreatedAt { get; set; }

    [JsonProperty(nameof(Currency))]
    public string Currency { get; set; }

    [JsonProperty(nameof(Description))]
    public string Description { get; set; }

    [JsonProperty(nameof(Excerpt))]
    public string Excerpt { get; set; }

    [JsonProperty(nameof(Level))]
    public string Level { get; set; }

    [JsonProperty(nameof(PostedDate))]
    public string PostedDate { get; set; }

    [JsonProperty(nameof(Title))]
    public string Title { get; set; }

    [JsonProperty(nameof(Type))]
    public string Type { get; set; }

    [JsonProperty(nameof(Url))]
    public string Url { get; set; }
    
    public JobVacancyCompany(int apiId, int annualSalaryMax, int annualSalaryMin, string companyLogo, string companyName, string createdAt, string currency, string description, string excerpt, string geoLocation, string industry, string level, string postedDate, string title, string type, string url)
    {
        ApiId = apiId;
        AnnualSalaryMax = annualSalaryMax;
        AnnualSalaryMin = annualSalaryMin;
        CompanyLogo = companyLogo;
        CompanyName = companyName;
        CreatedAt = createdAt;
        Currency = currency;
        Description = description;
        Excerpt = excerpt;
        GeoLocation = geoLocation;
        Industry = industry;
        Level = level;
        PostedDate = postedDate;
        Title = title;
        Type = type;
        Url = url;
    }
}