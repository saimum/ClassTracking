using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<T> GetAsync(long id);
        Task<T> FirstOrDefaultAsync(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null
            );
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null
            );
        Task<IQueryable<T>> GetAllAsyncQueryable(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task RemoveAsync(long id);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entity);
    }
}
