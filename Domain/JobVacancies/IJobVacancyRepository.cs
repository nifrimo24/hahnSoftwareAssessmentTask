namespace Domain.JobVacancies;

public interface IJobVacancyRepository
{
    Task AddAsync(JobVacancy jobVacancy);
    Task<bool> ExistsAsync(int id);
    Task<JobVacancy?> GetByIdAsync(int jobVacancyId );
}