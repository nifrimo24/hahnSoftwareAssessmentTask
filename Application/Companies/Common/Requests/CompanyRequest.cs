using Domain.JobVacancies;

namespace Application.Companies.Common.Requests;

public abstract record CompanyRequest(
    string CompanyName,
    string GeoLocation,
    string Industry,
    List<JobVacancy> JobVacancies
);