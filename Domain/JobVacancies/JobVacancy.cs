using Domain.Primitives;

namespace Domain.JobVacancies;

public class JobVacancy : AggregateRoot
{
    public JobVacancyId Id { get; private set; }
    public string AnnualSalaryMax { get; private set; }
    public string AnnualSalaryMin { get; private set; }
    public string CompanyName { get; private set; }
    public string Currency { get; private set; }
    public string Excerpt { get; private set; }
    public string GeoLocation { get; private set; }
    public string Industry { get; private set; }
    public string Level { get; private set; }
    public string PostedDate { get; private set; }
    public string Title { get; private set; }
    public string Type { get; private set; }
    public string Url { get; private set; }


    public JobVacancy(JobVacancyId id, string annualSalaryMax, string annualSalaryMin, string companyName,
        string currency, string excerpt,
        string geoLocation, string industry, string level, string postedDate, string title,
        string type, string url)
    {
        Id = id;
        AnnualSalaryMax = annualSalaryMax;
        AnnualSalaryMin = annualSalaryMin;
        CompanyName = companyName;
        Currency = currency;
        Excerpt = excerpt;
        GeoLocation = geoLocation;
        Industry = industry;
        Level = level;
        PostedDate = postedDate;
        Title = title;
        Type = type;
        Url = url;
    }

    public JobVacancy()
    {
    }
}