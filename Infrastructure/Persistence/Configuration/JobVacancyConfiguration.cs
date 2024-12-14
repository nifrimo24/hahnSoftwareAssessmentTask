using Domain.Companies;
using Domain.JobVacancies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class JobVacancyConfiguration : IEntityTypeConfiguration<JobVacancy>
{
    public void Configure(EntityTypeBuilder<JobVacancy> builder)
    {
        builder.ToTable("JobVacancies");

        builder.HasKey(jv => jv.Id);
        
        builder.Property(jv => jv.Id)
            .HasConversion(
                jobVacancyId => jobVacancyId.Value,
                value => new JobVacancyId(value)
            );

        builder.Property(jv => jv.CompanyId).IsRequired();

        builder.Property(jv => jv.AnnualSalaryMax).IsRequired().HasDefaultValue(0);

        builder.Property(jv => jv.AnnualSalaryMin).IsRequired().HasDefaultValue(0);
        
        builder.Property(jv => jv.CreatedAt).IsRequired();
        
        builder.Property(jv => jv.Currency).HasMaxLength(20);
        
        builder.Property(jv => jv.PostedDate).IsRequired();

        builder.Property(jv => jv.Title).HasMaxLength(50);
        
        builder.Property(jv => jv.Type).HasMaxLength(20);
    }
}