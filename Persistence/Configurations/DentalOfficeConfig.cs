using DCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class DentalOfficeConfig : IEntityTypeConfiguration<DentalOffice>
    {
        public void Configure(EntityTypeBuilder<DentalOffice> builder)
        {
            builder.Property(prop => prop.Name)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
