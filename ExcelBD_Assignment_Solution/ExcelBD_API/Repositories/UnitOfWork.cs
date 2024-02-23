using ExcelBD_API.Repositories.Interfaces;
using ExelBD_Shared.Models;

namespace ExcelBD_API.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExcelDbContext db;
        public UnitOfWork(ExcelDbContext db)
        {
            this.db = db;
        }
        public IGenericRepository<T> GetRepository<T>() where T : class, new()
        {
            return new GenericRepository<T>(db);
        }
        public async Task<bool> SaveAsync()
        {
            int rowsEffected = await db.SaveChangesAsync();
            return rowsEffected > 0;
        }
    }
}
