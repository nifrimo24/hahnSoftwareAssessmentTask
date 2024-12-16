using Newtonsoft.Json;

namespace WorkerServiceJobVacancyCompany.Application.Common;


public class JobVacancyCompanyAPIRequest
{
    [JsonProperty("JobVacancyCompanies")]
    public List<JobVacancyCompany> JobVacancyCompanies { get; set; }

    public JobVacancyCompanyAPIRequest(List<JobVacancyCompany> jobVacancyCompanies)
    {
        JobVacancyCompanies = jobVacancyCompanies;
    }
}

public class JobVacancyCompany
{
    [JsonProperty("ApiId")]
    public int ApiId { get; set; }

    [JsonProperty("CompanyName")]
    public string CompanyName { get; set; }

    [JsonProperty("CompanyLogo")]
    public string CompanyLogo { get; set; }

    [JsonProperty("GeoLocation")]
    public string GeoLocation { get; set; }

    [JsonProperty("Industry")]
    public string Industry { get; set; }

    [JsonProperty("AnnualSalaryMax")]
    public int AnnualSalaryMax { get; set; }

    [JsonProperty("AnnualSalaryMin")]
    public int AnnualSalaryMin { get; set; }

    [JsonProperty("CreatedAt")]
    public string CreatedAt { get; set; }

    [JsonProperty("Currency")]
    public string Currency { get; set; }

    [JsonProperty("Description")]
    public string Description { get; set; }

    [JsonProperty("Excerpt")]
    public string Excerpt { get; set; }

    [JsonProperty("Level")]
    public string Level { get; set; }

    [JsonProperty("PostedDate")]
    public string PostedDate { get; set; }

    [JsonProperty("Title")]
    public string Title { get; set; }

    [JsonProperty("Type")]
    public string Type { get; set; }

    [JsonProperty("Url")]
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