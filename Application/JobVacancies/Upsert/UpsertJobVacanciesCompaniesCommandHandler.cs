using Application.Companies.Create;
using Application.Companies.Update;
using Application.JobVacancies.Common.Requests;
using Application.JobVacancies.Common.Responses;
using Application.JobVacancies.Create;
using Application.JobVacancies.Update;
using Domain.Companies;
using Domain.JobVacancies;
using MediatR;

namespace Application.JobVacancies.Upsert;

internal class UpsertJobVacanciesCompaniesCommandHandler : IRequestHandler<UpsertJobVacanciesCompaniesCommand, List<JobVacancyCompanyResponse>>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IJobVacancyRepository _jobVacancyRepository;
    private readonly ISender _mediator;

    public UpsertJobVacanciesCompaniesCommandHandler(ICompanyRepository companyRepository, IJobVacancyRepository jobVacancyRepository, ISender mediator)
    {
        _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        _jobVacancyRepository = jobVacancyRepository ?? throw new ArgumentNullException(nameof(jobVacancyRepository));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<List<JobVacancyCompanyResponse>> Handle(UpsertJobVacanciesCompaniesCommand command,
        CancellationToken cancellationToken)
    {
        var registerNumber = 1;
        var responses = new List<JobVacancyCompanyResponse>();

        foreach (var request in command.JobVacancyCompanies)
        {
            var existingCompany = await _companyRepository.GetByCompanyNameAsync(request.CompanyName);

            var response = existingCompany != null
                ? await HandleExistingCompany(request, existingCompany.Id, registerNumber, cancellationToken)
                : await HandleNewCompany(request, registerNumber, cancellationToken);

            responses.Add(response);
            registerNumber++;
        }

        return responses;
    }

    private async Task<JobVacancyCompanyResponse> HandleExistingCompany(JobVacancyCompanyRequest request, int existingCompanyId, int registerNumber, CancellationToken cancellationToken)
    {
        var updatedCompanyId = await HandleUpdateCompany(request, existingCompanyId, cancellationToken);
        
        var existingJobVacancy = await _jobVacancyRepository.GetByIApiIdAsync(request.ApiId);

        var jobVacancyId = existingJobVacancy != null
            ? await HandleUpdateJobVacancy(request, existingJobVacancy.Id, cancellationToken)
            : await HandleCreateJobVacancy(request, existingCompanyId, cancellationToken);
        
        return new JobVacancyCompanyResponse(updatedCompanyId, jobVacancyId, registerNumber);
    }

    private async Task<JobVacancyCompanyResponse> HandleNewCompany(JobVacancyCompanyRequest request, int registerNumber, CancellationToken cancellationToken)
    {
        var companyCommand = new CreateCompanyCommand(
            request.CompanyName,
            request.CompanyLogo,
            request.GeoLocation,
            request.Industry
        );

        var newCompanyId = await _mediator.Send(companyCommand, cancellationToken);

        return await HandleExistingCompany(request, newCompanyId, registerNumber, cancellationToken);
    }
    
    private async Task<int> HandleUpdateCompany(JobVacancyCompanyRequest request, int existingId, CancellationToken cancellationToken )
    {
        var updateCompanyCommand = new UpdateCompanyCommand(
            existingId,
            request.CompanyLogo,
            request.GeoLocation,
            request.Industry
        );
        
        return await _mediator.Send(updateCompanyCommand, cancellationToken);
    }

    private async Task<int> HandleCreateJobVacancy(JobVacancyCompanyRequest request, int existingId, CancellationToken cancellationToken )
    {
        var createJobVacancyCommand = new CreateJobVacancyCommand(
            existingId,
            request.ApiId,
            request.AnnualSalaryMax,
            request.AnnualSalaryMin,
            request.CreatedAt,
            request.Currency,
            request.Description,
            request.Excerpt,
            request.Level,
            request.PostedDate,
            request.Title,
            request.Type,
            request.Url
        );
        
        return await _mediator.Send(createJobVacancyCommand, cancellationToken);
    }
    
    private async Task<int> HandleUpdateJobVacancy(JobVacancyCompanyRequest request, int existingId, CancellationToken cancellationToken )
    {
        var updateJobVacancyCommand = new UpdateJobVacancyCommand(
            existingId,
            request.AnnualSalaryMax,
            request.AnnualSalaryMin,
            request.CreatedAt,
            request.Currency,
            request.Description,
            request.Excerpt,
            request.Level,
            request.PostedDate,
            request.Title,
            request.Type,
            request.Url
        );
        
        return await _mediator.Send(updateJobVacancyCommand, cancellationToken);
    }
}