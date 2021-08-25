using InspectionStatistics.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InspectionStatistics.Persistence.Configuration
{
    public class InspectionConfiguration : IEntityTypeConfiguration<Inspection>
    {
        public void Configure(EntityTypeBuilder<Inspection> builder)
        {
            builder.Property(e => e.InspectionType)
                .IsRequired()
                .HasMaxLength(50);
        }

    }
}
