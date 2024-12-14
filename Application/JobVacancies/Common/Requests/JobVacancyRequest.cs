using Domain.Companies;

namespace Application.JobVacancies.Common.Requests;

public record JobVacancyRequest(
    int CompanyId,
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