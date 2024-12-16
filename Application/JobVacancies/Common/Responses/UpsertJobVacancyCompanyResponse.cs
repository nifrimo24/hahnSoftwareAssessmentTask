namespace Application.JobVacancies.Common.Responses;

public record UpsertJobVacancyCompanyResponse(
    int companyId,
    int jobVacancyId,
    int registerNumber
);