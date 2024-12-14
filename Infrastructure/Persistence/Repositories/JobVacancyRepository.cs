using Domain.JobVacancies;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class JobVacancyRepository : IJobVacancyRepository
{
    private readonly ApplicationDbContext _context;
    
    public JobVacancyRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task AddAsync(JobVacancy jobVacancy) => await _context.JobVacancies.AddAsync(jobVacancy);
    
    public async Task<JobVacancy?> GetByIdAsync(int jobVacancyId) => await _context.JobVacancies.SingleOrDefaultAsync(x => x.Id == jobVacancyId);
}