using Domain.Companies;
using Domain.Primitives;

namespace Domain.JobVacancies;

public class JobVacancy : AggregateRoot
{
    public int Id { get; private set; }
    public int CompanyId { get; private set; }
    public int AnnualSalaryMax { get; private set; }
    public int AnnualSalaryMin { get; private set; }
    public string CreatedAt { get; private set; }
    public string Currency { get; private set; }
    public string Excerpt { get; private set; }
    public string Level { get; private set; }
    public string PostedDate { get; private set; }
    public string Title { get; private set; }
    public string Type { get; private set; }
    public string Url { get; private set; }
    
    public Company Company { get; private set; }


    public JobVacancy(int companyId, int annualSalaryMax, int annualSalaryMin, string createdAt, string currency, string excerpt,
        string level, string postedDate, string title, string type, string url)
    {
        CompanyId = companyId;
        AnnualSalaryMax = annualSalaryMax;
        AnnualSalaryMin = annualSalaryMin;
        CreatedAt = createdAt;
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