using Application.Companies.Create;
using Application.JobVacancies.Common.Responses;
using Application.JobVacancies.Create;
using Domain.Companies;
using MediatR;

namespace Application.JobVacancies.Upsert;

internal class
    UpsertJobVacanciesCompaniesCommandHandler : IRequestHandler<UpsertJobVacanciesCompaniesCommand, List<JobVacancyCompanyResponse>>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly ISender _mediator;

    public UpsertJobVacanciesCompaniesCommandHandler(ICompanyRepository companyRepository, ISender mediator)
    {
        _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<List<JobVacancyCompanyResponse>> Handle(UpsertJobVacanciesCompaniesCommand command, CancellationToken cancellationToken)
    {
        List<JobVacancyCompanyResponse> jobVacancyCompanyResponse = [];
        var registerNumber = 0;
        
        foreach (var request in command.JobVacancyCompanies)
        {
            var companyExists = await _companyRepository.GetByCompanyNameAsync(request.CompanyName);

            if (companyExists != null)
            {
                CreateJobVacancyCommand existsCompanyJobVacancyCommand = new(
                    companyExists.Id,
                    request.AnnualSalaryMax,
                    request.AnnualSalaryMin,
                    request.CreatedAt,
                    request.Currency,
                    request.Excerpt,
                    request.Level,
                    request.PostedDate,
                    request.Title,
                    request.Type,
                    request.Url
                );

                var existsCompanyJobVacancyCreateResult =
                    await _mediator.Send(existsCompanyJobVacancyCommand, cancellationToken);
                
                var existsCompanyJobVacancyResponse = new JobVacancyCompanyResponse(
                    companyExists.Id,
                    existsCompanyJobVacancyCreateResult,
                    registerNumber++
                    
                );
                
                jobVacancyCompanyResponse.Add(existsCompanyJobVacancyResponse);
            }
            else
            {
                CreateCompanyCommand companyCommand = new(
                    request.CompanyName,
                    request.CompanyLogo,
                    request.GeoLocation,
                    request.Industry
                );

                var createCompanyResult = await _mediator.Send(companyCommand, cancellationToken);

                CreateJobVacancyCommand newCompanyJobVacancyCommand = new(
                    createCompanyResult,
                    request.AnnualSalaryMax,
                    request.AnnualSalaryMin,
                    request.CreatedAt,
                    request.Currency,
                    request.Excerpt,
                    request.Level,
                    request.PostedDate,
                    request.Title,
                    request.Type,
                    request.Url
                );

                var newCompanyJobVacancyResult = await _mediator.Send(newCompanyJobVacancyCommand, cancellationToken);
            
                var newCompanyJobVacancyResponse = new JobVacancyCompanyResponse(
                    createCompanyResult,
                    newCompanyJobVacancyResult,
                    registerNumber++
                );
            
                jobVacancyCompanyResponse.Add(newCompanyJobVacancyResponse);
            }
        }
        
        return jobVacancyCompanyResponse;
    }
}