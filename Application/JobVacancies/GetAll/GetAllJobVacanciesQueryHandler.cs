using Application.JobVacancies.Common.Responses;
using Domain.Companies;
using Domain.JobVacancies;
using MediatR;

namespace Application.JobVacancies.GetAll;

internal class GetAllJobVacanciesQueryHandler : IRequestHandler<GetAllJobVacanciesQuery, IReadOnlyList<GetAllJobVacancyCompanyResponse>>
{
    private readonly IJobVacancyRepository _jobVacancyRepository; 
    private readonly ICompanyRepository _companyRepository;
    
    public GetAllJobVacanciesQueryHandler(IJobVacancyRepository jobVacancyRepository, ICompanyRepository companyRepository)
    {
        _jobVacancyRepository = jobVacancyRepository ?? throw new ArgumentNullException(nameof(jobVacancyRepository));
        _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
    }
    
    public async Task<IReadOnlyList<GetAllJobVacancyCompanyResponse>> Handle(GetAllJobVacanciesQuery query, CancellationToken cancellationToken)
    {
        var jobVacancies = await _jobVacancyRepository.GetAllJobVacancies();
        
        return jobVacancies.Select(jobVacancy => new GetAllJobVacancyCompanyResponse(
            jobVacancy.Id,
            jobVacancy.ApiId,
            jobVacancy.AnnualSalaryMax,
            jobVacancy.AnnualSalaryMin,
            jobVacancy.CompanyId,
            jobVacancy.Company.CompanyLogo,
            jobVacancy.Company.CompanyName,
            jobVacancy.CreatedAt,
            jobVacancy.Currency,
            jobVacancy.Description,
            jobVacancy.Excerpt,
            jobVacancy.Company.GeoLocation,
            jobVacancy.Company.Industry,
            jobVacancy.Level,
            jobVacancy.PostedDate,
            jobVacancy.Title,
            jobVacancy.Type,
            jobVacancy.Url
            )).ToList();
        
    }
}