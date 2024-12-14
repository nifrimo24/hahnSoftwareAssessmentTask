using Application.Companies.Common.Requests;
using MediatR;

namespace Application.Companies.Create;

public record CreateCompanyCommand(
    List<CompanyRequest> CompanyRequests
) : IRequest<Unit>;