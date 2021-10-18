using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagement.Domain.Context;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DbSet<T> Entities => DbContext.Set<T>();

        public DatabaseContext DbContext { get; private set; }

        public Repository(DatabaseContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task DeleteAsync(int id, bool saveChanges = true)
        {
            var entity = await Entities.FindAsync(id);
            await DeleteAsync(entity);

            if (saveChanges)
            {
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(T entity, bool saveChanges = true)
        {
            Entities.Remove(entity);
            if (saveChanges)
            {
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities, bool saveChanges = true)
        {
            var enumerable = entities as T[] ?? entities.ToArray();
            if (enumerable.Any())
            {
                Entities.RemoveRange(enumerable);
            }

            if (saveChanges)
            {
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public T Find(params object[] keyValues)
        {
            return Entities.Find(keyValues);
        }

        public virtual async Task<T> FindAsync(params object[] keyValues)
        {
            return await Entities.FindAsync(keyValues);
        }

        public async Task InsertAsync(T entity, bool saveChanges = true)
        {
            await Entities.AddAsync(entity);

            if (saveChanges)
            {
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task InsertRangeAsync(IEnumerable<T> entities, bool saveChanges = true)
        {
            await DbContext.AddRangeAsync(entities);

            if (saveChanges)
            {
                await DbContext.SaveChangesAsync();
            }
        }
    }
}