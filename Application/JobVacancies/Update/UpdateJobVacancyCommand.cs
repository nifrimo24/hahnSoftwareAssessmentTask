using MediatR;

namespace Application.JobVacancies.Update;

public record UpdateJobVacancyCommand(
    int Id,
    int CompanyId,
    int ApiId,
    int AnnualSalaryMax,
    int AnnualSalaryMin,
    string CreatedAt,
    string Currency,
    string Description,
    string Excerpt,
    string Level,
    string PostedDate,
    string Title,
    string Type,
    string Url
) : IRequest<int>;