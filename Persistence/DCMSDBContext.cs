using DCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DCMS.Persistence
{
    public class DCMSDBContext : DbContext
    {
        public DCMSDBContext(DbContextOptions<DCMSDBContext> options) : base(options)
        {
            
        }

        protected DCMSDBContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DCMSDBContext).Assembly);
        }

        public DbSet<DentalOffice> DentalOffices { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Dentist> Dentists { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
