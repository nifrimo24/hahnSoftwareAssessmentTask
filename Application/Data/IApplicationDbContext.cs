using Domain.JobVacancies;
using Domain.Companies;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<JobVacancy> JobVacancies { get; set; }
    DbSet<Company> Companies { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}