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

        builder.Property(jv => jv.CompanyId).IsRequired();

        builder.Property(jv => jv.AnnualSalaryMax).IsRequired().HasDefaultValue(0);

        builder.Property(jv => jv.AnnualSalaryMin).IsRequired().HasDefaultValue(0);
        
        builder.Property(jv => jv.CreatedAt).IsRequired();
        
        builder.Property(jv => jv.Currency).HasMaxLength(20);
        
        builder.Property(jv => jv.Description)
            .IsRequired()
            .HasColumnType("text");

        builder.Property(jv => jv.Excerpt)
            .IsRequired()
            .HasColumnType("text");
        
        builder.Property(jv => jv.PostedDate).IsRequired();

        builder.Property(jv => jv.Title).HasMaxLength(150);
        
        builder.Property(jv => jv.Type).HasMaxLength(100);
    }
}