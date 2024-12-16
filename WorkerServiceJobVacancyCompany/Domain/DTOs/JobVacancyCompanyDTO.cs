using Newtonsoft.Json;

namespace WorkerServiceJobVacancyCompany.Domain.DTOs;

public class JobVacancyCompanyDTO
{
    [JsonProperty("apiVersion")]
    public string ApiVersion { get; set; }

    [JsonProperty("documentationUrl")]
    public string DocumentationUrl { get; set; }

    [JsonProperty("friendlyNotice")]
    public string FriendlyNotice { get; set; }

    [JsonProperty("jobCount")]
    public int JobCount { get; set; }

    [JsonProperty("xRayHash")]
    public string XRayHash { get; set; }

    [JsonProperty("clientKey")]
    public string ClientKey { get; set; }

    [JsonProperty("lastUpdate")]
    public string LastUpdate { get; set; }

    [JsonProperty("jobs")]
    public List<JobVacancyCompanyAPI> Jobs { get; set; }
}

public class JobVacancyCompanyAPI
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("jobSlug")]
    public string JobSlug { get; set; }

    [JsonProperty("jobTitle")]
    public string JobTitle { get; set; }

    [JsonProperty("companyName")]
    public string CompanyName { get; set; }

    [JsonProperty("companyLogo")]
    public string CompanyLogo { get; set; }

    [JsonProperty("jobIndustry")]
    public List<string> JobIndustry { get; set; }

    [JsonProperty("jobType")]
    public List<string> JobType { get; set; }

    [JsonProperty("jobGeo")]
    public string JobGeo { get; set; }

    [JsonProperty("jobLevel")]
    public string JobLevel { get; set; }

    [JsonProperty("jobExcerpt")]
    public string JobExcerpt { get; set; }

    [JsonProperty("jobDescription")]
    public string JobDescription { get; set; }

    [JsonProperty("pubDate")]
    public string PubDate { get; set; }

    [JsonProperty("annualSalaryMin")]
    public int? AnnualSalaryMin { get; set; }

    [JsonProperty("annualSalaryMax")]
    public int? AnnualSalaryMax { get; set; }

    [JsonProperty("salaryCurrency")]
    public string? SalaryCurrency { get; set; }
}