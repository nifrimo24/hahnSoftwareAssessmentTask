using Domain.Companies;
using MediatR;

namespace Application.Companies.Create;

public record CreateCompanyCommand(
    string CompanyName,
    string CompanyLogo,
    string GeoLocation,
    string Industry
) : IRequest<CompanyId>;