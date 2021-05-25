using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ImPossibleFoundation.Common
{
    public interface IRepository<T, TKey>
    {
        Task<T> GetAsync(TKey id);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> order = null, string includeDetails = null);

        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null, string includeDetails = null);

        Task<T> InsertAsync(T entity);

        Task<T> RemoveAsync(TKey id);

    }
}