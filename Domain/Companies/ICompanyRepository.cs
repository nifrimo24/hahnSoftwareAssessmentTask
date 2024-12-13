namespace Domain.Companies;

public interface ICompanyRepository
{
    Task AddAsync(Company company);
    Task<Company?> GetByIdAsync(CompanyId companyId);
}