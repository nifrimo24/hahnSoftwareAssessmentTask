namespace Domain.JobVacancies;

public interface IJobVacancyRepository
{
    Task<JobVacancy> GetByIdAsync(JobVacancyId jobVacancyId );
    Task AddAsync(JobVacancy jobVacancy);
}