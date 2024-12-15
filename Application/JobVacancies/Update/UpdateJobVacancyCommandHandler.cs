using Domain.JobVacancies;
using Domain.Primitives;
using MediatR;

namespace Application.JobVacancies.Update;

internal class UpdateJobVacancyCommandHandler : IRequestHandler<UpdateJobVacancyCommand, int>
{
    private readonly IJobVacancyRepository _jobVacancyRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public UpdateJobVacancyCommandHandler(IJobVacancyRepository jobVacancyRepository, IUnitOfWork unitOfWork)
    {
        _jobVacancyRepository = jobVacancyRepository ?? throw new ArgumentNullException(nameof(jobVacancyRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    
    public async Task<int> Handle(UpdateJobVacancyCommand command, CancellationToken cancellationToken)
    {
        if (!await _jobVacancyRepository.ExistsAsync(command.Id))
        {
            throw new ArgumentNullException(nameof(command.Id));
        }

        var updateJobVacancy = await _jobVacancyRepository.GetByIdAsync(command.Id);
        
        updateJobVacancy.AnnualSalaryMax = command.AnnualSalaryMax;
        updateJobVacancy.AnnualSalaryMin = command.AnnualSalaryMin;
        updateJobVacancy.CreatedAt = command.CreatedAt;
        updateJobVacancy.Currency = command.Currency;
        updateJobVacancy.Description = command.Description;
        updateJobVacancy.Excerpt = command.Excerpt;
        updateJobVacancy.Level = command.Level;
        updateJobVacancy.PostedDate = command.PostedDate;
        updateJobVacancy.Title = command.Title;
        updateJobVacancy.Type = command.Type;
        updateJobVacancy.Url = command.Url;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return updateJobVacancy.Id;
    }
}