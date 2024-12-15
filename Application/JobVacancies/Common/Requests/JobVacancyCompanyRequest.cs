using Domain.Companies;

namespace Application.JobVacancies.Common.Requests;

public record JobVacancyCompanyRequest(
    int ApiId,
    int AnnualSalaryMax,
    int AnnualSalaryMin,
    string CompanyLogo,
    string CompanyName,
    string CreatedAt,
    string Currency,
    string Description,
    string Excerpt,
    string GeoLocation,
    string Industry,
    string Level,
    string PostedDate,
    string Title,
    string Type,
    string Url
);