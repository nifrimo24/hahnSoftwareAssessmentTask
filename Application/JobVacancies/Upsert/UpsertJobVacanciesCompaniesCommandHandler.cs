using Application.Companies.Create;
using Application.JobVacancies.Create;
using Domain.Companies;
using MediatR;

namespace Application.JobVacancies.Upsert;

internal class UpsertJobVacanciesCompaniesCommandHandler : IRequestHandler<UpsertJobVacanciesCompaniesCommand, List<int>>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly ISender _mediator;

    public UpsertJobVacanciesCompaniesCommandHandler(ICompanyRepository companyRepository, ISender mediator)
    {
        _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<List<int>> Handle(UpsertJobVacanciesCompaniesCommand command, CancellationToken cancellationToken)
    {
        var companyExists = await _companyRepository.GetByCompanyNameAsync(command.CompanyName);

        if (companyExists != null)
        {
            CreateJobVacancyCommand existsCompanyJobVacancyCommand = new(
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

            var existsCompanyJobVacancyResult = await _mediator.Send(existsCompanyJobVacancyCommand, cancellationToken);

            return [companyExists.Id, existsCompanyJobVacancyResult];
        }

        CreateCompanyCommand companyCommand = new(
            command.CompanyName,
            command.CompanyLogo,
            command.GeoLocation,
            command.Industry
        );

        var createCompanyResult = await _mediator.Send(companyCommand, cancellationToken);

        CreateJobVacancyCommand newCompanyJobVacancyCommand = new(
            createCompanyResult,
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

        var newCompanyJobVacancyResult = await _mediator.Send(newCompanyJobVacancyCommand, cancellationToken);

        return [createCompanyResult, newCompanyJobVacancyResult];
    }
}