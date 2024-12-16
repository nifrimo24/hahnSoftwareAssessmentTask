using Domain.Companies;
using Domain.Primitives;

namespace Domain.JobVacancies;

public class JobVacancy : AggregateRoot
{
    public int Id { get; private set; }
    public int CompanyId { get; private set; }
    public int ApiId { get;  private set; }
    public int AnnualSalaryMax { get; set; }
    public int AnnualSalaryMin { get; set; }
    public string CreatedAt { get; set; }
    public string Currency { get; set; }
    public string Description { get; set; }
    public string Excerpt { get; set; }
    public string Level { get; set; }
    public string PostedDate { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public string Url { get; set; }
    
    public Company Company { get; set; }


    public JobVacancy(int companyId, int apiId, int annualSalaryMax, int annualSalaryMin, string createdAt, string currency, string description, string excerpt,
        string level, string postedDate, string title, string type, string url)
    {
        CompanyId = companyId;
        ApiId = apiId;
        AnnualSalaryMax = annualSalaryMax;
        AnnualSalaryMin = annualSalaryMin;
        CreatedAt = createdAt;
        Currency = currency;
        Description = description;
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