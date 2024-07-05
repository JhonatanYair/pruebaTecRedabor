using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using PruebaRedarbor.Infrastruture;

namespace PruebaRedarbor.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PruebaRebardorContext _context;

        public Repository(PruebaRebardorContext context)
        {
            _context = context;
        }

        public async Task<List<T>> ListRecords(CancellationToken cancellationToken, Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includes != null && includes.Any())
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<T> CreateRecord(T entidad,CancellationToken cancellationToken)
        {
            _context.Set<T>().Add(entidad);
            await _context.SaveChangesAsync(cancellationToken);
            return entidad;
        }

        public async Task<T> UpdateRecord(T entidad, CancellationToken cancellationToken)
        {
            _context.Set<T>().Update(entidad);
            await _context.SaveChangesAsync();
            return entidad;
        }

        public async Task<bool> DeleteRecord(int id,CancellationToken cancellationToken)
        {
            var entidad = await _context.Set<T>().FindAsync(id);
            if (entidad == null)
            {
                return false;
            }

            _context.Set<T>().Remove(entidad);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
