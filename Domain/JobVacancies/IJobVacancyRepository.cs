namespace Domain.JobVacancies;

public interface IJobVacancyRepository
{
    Task AddAsync(JobVacancy jobVacancy);
    Task<JobVacancy?> GetByIdAsync(int jobVacancyId );
}