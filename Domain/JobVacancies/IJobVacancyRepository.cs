﻿namespace Domain.JobVacancies;

public interface IJobVacancyRepository
{
    Task AddAsync(JobVacancy jobVacancy);
    Task<bool> ExistsAsync(int id);
    Task<JobVacancy?> GetByIApiIdAsync(int jobVacancyApiId);
    Task<JobVacancy?> GetByIdAsync(int jobVacancyId );
    Task<IReadOnlyList<JobVacancy>> GetAllJobVacancies();
}