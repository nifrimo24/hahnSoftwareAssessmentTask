using Domain.JobVacancies;

namespace Application.Companies.Common.Requests;

public record CompanyRequest(
    string CompanyName,
    string GeoLocation,
    string Industry
);