namespace Domain.Companies;

public interface ICompanyRepository
{
    Task AddAsync(Company company);
    Task<Company?> GetByIdAsync(int companyId);
    Task<Company?> GetByCompanyNameAsync(string companyName);
}