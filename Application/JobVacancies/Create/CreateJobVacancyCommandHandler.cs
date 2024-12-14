using Domain.JobVacancies;
using Domain.Primitives;
using MediatR;

namespace Application.JobVacancies.Create;

internal class CreateJobVacancyCommandHandler : IRequestHandler<CreateJobVacancyCommand, JobVacancyId>
{
    private readonly IJobVacancyRepository _jobVacancyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateJobVacancyCommandHandler(IJobVacancyRepository jobVacancyRepository, IUnitOfWork unitOfWork)
    {
        _jobVacancyRepository = jobVacancyRepository ?? throw new ArgumentNullException(nameof(jobVacancyRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<JobVacancyId> Handle(CreateJobVacancyCommand command, CancellationToken cancellationToken)
    {
        var jobVacancy = new JobVacancy(
            new JobVacancyId(Guid.NewGuid()),
            command.CompanyId,
            command.AnnualSalaryMax,
            command.AnnualSalaryMin,
            command.CreatedAt,
            command.Currency,
            command.Excerpt,
            command.Level,
            command.PostedDate,
            command.Title,
            command.Type,
            command.Url
        );
        
        await _jobVacancyRepository.AddAsync(jobVacancy);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return jobVacancy.Id;
    }
}