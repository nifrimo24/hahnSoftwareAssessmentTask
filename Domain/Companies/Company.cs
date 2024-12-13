using Domain.JobVacancies;
using Domain.Primitives;

namespace Domain.Companies;

public class Company : AggregateRoot
{
    public CompanyId Id { get; private set; }
    public string CompanyName { get; private set; }
    public string GeoLocation { get; private set; }
    public string Industry { get; private set; }
    
    public  List<JobVacancy> JobVacancies { get; private set; }
    
    public Company(CompanyId companyId, string companyName, string geoLocation, string industry, List<JobVacancy> jobVacancies)
    {
        Id = companyId;
        CompanyName = companyName;
        GeoLocation = geoLocation;
        Industry = industry;
        JobVacancies = jobVacancies;
    }
    
    public Company() { }
}