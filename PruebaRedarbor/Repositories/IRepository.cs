using System.Linq.Expressions;

namespace PruebaRedarbor.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>> ListRecords(CancellationToken cancellationToken, Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[]? includes);
        Task<T> CreateRecord(T entidad,CancellationToken cancellationToken);
        Task<T> UpdateRecord(T entidad, CancellationToken cancellationToken);
        Task<bool> DeleteRecord(int id, CancellationToken cancellationToken);
    }
}
