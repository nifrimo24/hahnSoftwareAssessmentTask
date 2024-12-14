using Domain.Companies;
using Domain.Primitives;
using MediatR;

namespace Application.Companies.Create;

internal class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CompanyId>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
    {
        _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<CompanyId> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
    {
        var company = new Company(
            new CompanyId(Guid.NewGuid()),
            command.CompanyName,
            command.CompanyLogo,
            command.GeoLocation,
            command.Industry
        );
        
        await _companyRepository.AddAsync(company);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return company.Id;
    }
}