using MediatR;

namespace Application.Companies.Update;

public record UpdateCompanyCommand(
    int Id,
    string CompanyLogo,
    string GeoLocation,
    string Industry
) : IRequest<int>;