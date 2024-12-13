using Application.JobVacancies.Common.Requests;
using MediatR;

namespace Application.JobVacancies.Create;

public abstract record CreateJobVacancyCommand(
    List<JobVacancyRequest> JobVacancyRequests
) : IRequest<Unit>;