using Application.Companies.Create;
using Application.JobVacancies.Common.Requests;
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
        var command = new CreateJobVacancyCommand(
            existingCompanyId,
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

        var result = await _mediator.Send(command, cancellationToken);
        return new JobVacancyCompanyResponse(existingCompanyId, result, registerNumber);
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
}