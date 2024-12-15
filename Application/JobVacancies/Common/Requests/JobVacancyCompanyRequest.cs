﻿using Domain.Companies;

namespace Application.JobVacancies.Common.Requests;

public record JobVacancyCompanyRequest(
    string CompanyName,
    string CompanyLogo,
    string GeoLocation,
    string Industry,
    int AnnualSalaryMax,
    int AnnualSalaryMin,
    string CreatedAt,
    string Currency,
    string Excerpt,
    string Level,
    string PostedDate,
    string Title,
    string Type,
    string Url
);