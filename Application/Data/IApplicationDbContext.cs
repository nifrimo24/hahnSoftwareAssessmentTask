using Domain.JobVacancies;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<JobVacancy> JobVacancies { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}