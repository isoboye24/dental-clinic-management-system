using DCMS.Application.Contracts.Repositories;
using DCMS.Domain.Entities;

namespace DCMS.Persistence.Repositories
{
    public class DentalOfficeRepository : Repository<DentalOffice>, IDentalOfficeRepository
    {
        public DentalOfficeRepository(DCMSDBContext db) : base(db)
        {            

        }
    }
}

