using DCMS.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DCMS.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DCMSDBContext _db;

        public Repository(DCMSDBContext db)
        {
            _db = db;
        }

        public Task<T> Add(T entity)
        {
            _db.Add(entity);
            return Task.FromResult(entity);
        }

        public Task Delete(T entity)
        {
            _db.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<int> GetTotalAmountOfRecords()
        {
            return await _db.Set<T>().CountAsync();
        }

        public Task Update(T entity)
        {
            _db.Update(entity);
            return Task.CompletedTask;
        }
    }
}
