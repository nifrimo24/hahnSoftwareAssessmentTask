using Application.JobVacancies.Common.Requests;
using MediatR;

namespace Application.JobVacancies.Create;

public record CreateJobVacancyCommand(
    List<JobVacancyRequest> JobVacancyRequests
) : IRequest<Unit>;