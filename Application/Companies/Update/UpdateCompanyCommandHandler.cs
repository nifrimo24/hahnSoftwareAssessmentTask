using Domain.Companies;
using Domain.Primitives;
using MediatR;

namespace Application.Companies.Update;

internal class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, int>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public UpdateCompanyCommandHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
    {
        _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    
    public async Task<int> Handle(UpdateCompanyCommand command, CancellationToken cancellationToken)
    {
        if (!await _companyRepository.ExistsAsync(command.Id))
        {
            throw new ArgumentNullException(nameof(command.Id));
        }

        var updateCompany = await _companyRepository.GetByIdAsync(command.Id);
        
        updateCompany.CompanyLogo = command.CompanyLogo;
        updateCompany.GeoLocation = command.GeoLocation;
        updateCompany.Industry = command.Industry;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return updateCompany.Id;
    }
    
}