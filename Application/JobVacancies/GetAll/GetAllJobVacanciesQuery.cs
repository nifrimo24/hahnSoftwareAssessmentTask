using Application.JobVacancies.Common.Responses;
using MediatR;

namespace Application.JobVacancies.GetAll;

public record GetAllJobVacanciesQuery() : IRequest<IReadOnlyList<GetAllJobVacancyCompanyResponse>>;