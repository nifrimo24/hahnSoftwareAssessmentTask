using Domain.Companies;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly ApplicationDbContext _context;

    public CompanyRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task AddAsync(Company company) => await _context.Companies.AddAsync(company);
    public Task<Company?> GetByIdAsync(CompanyId companyId) => _context.Companies.SingleOrDefaultAsync(x => x.Id == companyId);
}