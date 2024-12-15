namespace Application.JobVacancies.Common.Responses;

public record JobVacancyCompanyResponse(
    int companyId,
    int jobVacancyId,
    int registerNumber
);