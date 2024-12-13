using Domain.Companies;
using Domain.Primitives;
using MediatR;

namespace Application.Companies.Create;

internal class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Unit>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
    {
        _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Unit> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
    {
        foreach (var company in command.CompanyRequests.Select(request => new Company(
                     new CompanyId(Guid.NewGuid()),
                     request.CompanyName,
                     request.GeoLocation,
                     request.Industry,
                     request.JobVacancies
                 )))
        {
            await _companyRepository.AddAsync(company);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}