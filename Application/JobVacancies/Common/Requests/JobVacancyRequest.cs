using Domain.Companies;

namespace Application.JobVacancies.Common.Requests;

public abstract record JobVacancyRequest(
    CompanyId CompanyId,
    int AnnualSalaryMax,
    int AnnualSalaryMin,
    string CreatedAt,
    string Currency,
    string Excerpt,
    string Level,
    string PostedDate,
    string Title,
    string Type,
    string Url
);