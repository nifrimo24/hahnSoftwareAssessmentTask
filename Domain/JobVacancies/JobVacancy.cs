using Domain.Companies;
using Domain.Primitives;

namespace Domain.JobVacancies;

public class JobVacancy : AggregateRoot
{
    public JobVacancyId Id { get; private set; }
    public int CompanyId { get; private set; }
    public string AnnualSalaryMax { get; private set; }
    public string AnnualSalaryMin { get; private set; }
    public string Currency { get; private set; }
    public string Excerpt { get; private set; }
    public string Level { get; private set; }
    public string PostedDate { get; private set; }
    public string Title { get; private set; }
    public string Type { get; private set; }
    public string Url { get; private set; }
    
    public Company Company { get; private set; }


    public JobVacancy(JobVacancyId id, int companyId, string annualSalaryMax, string annualSalaryMin, string currency, string excerpt,
        string level, string postedDate, string title, string type, string url)
    {
        Id = id;
        CompanyId = companyId;
        AnnualSalaryMax = annualSalaryMax;
        AnnualSalaryMin = annualSalaryMin;
        Currency = currency;
        Excerpt = excerpt;
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