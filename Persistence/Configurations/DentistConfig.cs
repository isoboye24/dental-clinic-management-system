using DCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DCMS.Persistence.Configurations
{
    public class DentistConfig : IEntityTypeConfiguration<Dentist>
    {
        public void Configure(EntityTypeBuilder<Dentist> builder)
        {
            builder.Property(prop => prop.Name)
               .IsRequired()
               .HasMaxLength(250);

            builder.ComplexProperty(prop => prop.Email, action =>
            {
                action.Property(e => e.Value)
                .HasColumnName("email")
                .HasMaxLength(254);
            });
        }
    }
}
