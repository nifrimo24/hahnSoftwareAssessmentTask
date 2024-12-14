using Domain.JobVacancies;
using MediatR;

namespace Application.JobVacancies.Create;

public record CreateJobVacancyCommand(
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
) : IRequest<JobVacancyId>;