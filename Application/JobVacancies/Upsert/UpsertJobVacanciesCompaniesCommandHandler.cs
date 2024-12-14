using Domain.Companies;
using Domain.JobVacancies;
using Domain.Primitives;
using MediatR;

namespace Application.JobVacancies.Upsert;

internal class UpsertJobVacanciesCompaniesCommandHandler : IRequestHandler<UpsertJobVacanciesCompaniesCommand, List<int>>
{
    private readonly IJobVacancyRepository _jobVacancyRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpsertJobVacanciesCompaniesCommandHandler(IJobVacancyRepository jobVacancyRepository,
        ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
    {
        _jobVacancyRepository = jobVacancyRepository ?? throw new ArgumentNullException(nameof(jobVacancyRepository));
        _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<List<int>> Handle(UpsertJobVacanciesCompaniesCommand command, CancellationToken cancellationToken)
    {
        var companyExists = await _companyRepository.GetByCompanyNameAsync(command.CompanyName);

        if (companyExists != null)
        {
            var jobVacancy1 = new JobVacancy(
                companyExists.Id,
                command.AnnualSalaryMax,
                command.AnnualSalaryMin,
                command.CreatedAt,
                command.Currency,
                command.Excerpt,
                command.Level,
                command.PostedDate,
                command.Title,
                command.Type,
                command.Url
            );

            await _jobVacancyRepository.AddAsync(jobVacancy1);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new List<int> { companyExists.Id, jobVacancy1.Id };
        }

        var company = new Company(
            command.CompanyName,
            command.CompanyLogo,
            command.GeoLocation,
            command.Industry
        );

        await _companyRepository.AddAsync(company);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var jobVacancy = new JobVacancy(
            company.Id,
            command.AnnualSalaryMax,
            command.AnnualSalaryMin,
            command.CreatedAt,
            command.Currency,
            command.Excerpt,
            command.Level,
            command.PostedDate,
            command.Title,
            command.Type,
            command.Url
        );

        await _jobVacancyRepository.AddAsync(jobVacancy);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new List<int> { company.Id, jobVacancy.Id };
    }
}