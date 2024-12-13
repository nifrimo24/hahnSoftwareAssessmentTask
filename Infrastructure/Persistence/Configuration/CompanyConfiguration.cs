using Domain.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");

        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Id)
            .HasConversion(
                companyId => companyId.Value,
                value => new CompanyId(value)
            );
        
        builder.Property(c => c.CompanyName).HasMaxLength(50);
        
        builder.Property(c => c.GeoLocation).HasMaxLength(50);
        
        builder.Property(c => c.Industry).HasMaxLength(50);
        
        builder.HasMany(c => c.JobVacancies)
            .WithOne(jv => jv.Company)
            .HasForeignKey(jv => jv.CompanyId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}