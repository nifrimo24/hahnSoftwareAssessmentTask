using Domain.JobVacancies;
using Domain.Primitives;
using MediatR;

namespace Application.JobVacancies.Create;

internal class CreateJobVacancyCommandHandler : IRequestHandler<CreateJobVacancyCommand, Unit>
{
    private readonly IJobVacancyRepository _jobVacancyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateJobVacancyCommandHandler(IJobVacancyRepository jobVacancyRepository, IUnitOfWork unitOfWork)
    {
        _jobVacancyRepository = jobVacancyRepository ?? throw new ArgumentNullException(nameof(jobVacancyRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Unit> Handle(CreateJobVacancyCommand command, CancellationToken cancellationToken)
    {
        foreach (var jobVacancy in command.JobVacancyRequests.Select(request => new JobVacancy(
                     new JobVacancyId(Guid.NewGuid()),
                     request.CompanyId,
                     request.AnnualSalaryMax,
                     request.AnnualSalaryMin,
                     request.CreatedAt,
                     request.Currency,
                     request.Excerpt,
                     request.Level,
                     request.PostedDate,
                     request.Title,
                     request.Type,
                     request.Url
                 )))
        {
            await _jobVacancyRepository.AddAsync(jobVacancy);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}