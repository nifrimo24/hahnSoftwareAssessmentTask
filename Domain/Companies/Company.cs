using Domain.JobVacancies;
using Domain.Primitives;

namespace Domain.Companies;

public class Company : AggregateRoot
{
    public int Id { get; private set; }
    public string CompanyName { get; private set; }
    public string CompanyLogo { get; private set; }
    public string GeoLocation { get; private set; }
    public string Industry { get; private set; }

    public List<JobVacancy> JobVacancies { get; private set; }

    public Company(string companyName, string companyLogo, string geoLocation, string industry)
    {
        CompanyName = companyName;
        CompanyLogo = companyLogo;
        GeoLocation = geoLocation;
        Industry = industry;
    }

    public Company()
    {
    }
}