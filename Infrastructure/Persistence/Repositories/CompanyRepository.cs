﻿using Domain.Companies;
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
    public async Task<bool> ExistsAsync(int companyId) => await _context.Companies.AnyAsync(x => x.Id == companyId);
    public Task<Company?> GetByIdAsync(int companyId) => _context.Companies.SingleOrDefaultAsync(x => x.Id == companyId);
    public Task<Company?> GetByCompanyNameAsync(string companyName) => _context.Companies.SingleOrDefaultAsync(x => x.CompanyName == companyName);
}