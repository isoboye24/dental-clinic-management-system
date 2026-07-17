using DCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DCMS.Persistence.Configurations
{
    public class AppointmentConfig : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ComplexProperty(prop => prop.TimeInterval, action =>
            {
                action.Property(e => e.Start).HasColumnName("startDate");
                action.Property(e => e.End).HasColumnName("endDate");
            });
        }
    }
}
