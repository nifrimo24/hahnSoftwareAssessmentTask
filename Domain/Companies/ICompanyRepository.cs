namespace Domain.Companies;

public interface ICompanyRepository
{
    Task<Company> GetByIdAsync(CompanyId companyId);
    Task AddAsync(Company company);
}