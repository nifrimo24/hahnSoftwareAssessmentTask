namespace Application.JobVacancies.Common.Responses;

public record GetAllJobVacancyCompanyResponse(
    int Id,
    int ApiId,
    int AnnualSalaryMax,
    int AnnualSalaryMin,
    int CompanyId,
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