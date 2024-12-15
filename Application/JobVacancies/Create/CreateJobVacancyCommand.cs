using Domain.JobVacancies;
using MediatR;

namespace Application.JobVacancies.Create;

public record CreateJobVacancyCommand(
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