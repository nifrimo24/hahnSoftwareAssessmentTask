using Application.JobVacancies.Common.Requests;
using Application.JobVacancies.Common.Responses;
using MediatR;

namespace Application.JobVacancies.Upsert;

public record UpsertJobVacanciesCompaniesCommand(
    List<JobVacancyCompanyRequest> JobVacancyCompanies
) : IRequest<List<UpsertJobVacancyCompanyResponse>>;