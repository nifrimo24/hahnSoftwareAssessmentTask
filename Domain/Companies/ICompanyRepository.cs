﻿namespace Domain.Companies;

public interface ICompanyRepository
{
    Task AddAsync(Company company);
    Task<bool> ExistsAsync(int companyId);
    Task<Company?> GetByIdAsync(int companyId);
    Task<Company?> GetByCompanyNameAsync(string companyName);
}