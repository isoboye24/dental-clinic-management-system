using DCMS.Application.Contracts.Persistence;

namespace DCMS.Persistence.UnitOfWork
{
    public class UnitOfWorkEFCore : IUnitOfWork
    {
        private readonly DCMSDBContext _db;

        public UnitOfWorkEFCore(DCMSDBContext db)
        {
            _db = db;
        }

        public async Task Commit()
        {
            await _db.SaveChangesAsync();
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
