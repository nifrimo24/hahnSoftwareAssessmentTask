using Domain.JobVacancies;
using Domain.Companies;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Company> Companies { get; set; }
    DbSet<JobVacancy> JobVacancies { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}