using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo.Implementation
{
    public class AsyncQueryBuilder<T> : IAsyncQueryBuilder<T> where T : class

    {
        private IQueryable<T> _query;
        public AsyncQueryBuilder(IQueryable<T> query)
        {
            _query = query;
        }
        public async Task<IList<T>> AsListAsync() =>await  _query.ToListAsync();

        public IAsyncQueryBuilder<T> Filter(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null) return this;
            _query = _query.Where(predicate);
            return this;
        }
        public async Task<T> SingleResultAsync() => await _query.FirstOrDefaultAsync();

        public IAsyncQueryBuilder<T> JoinWith(Expression<Func<T, object>> join)
        {
            _query = _query.Include(join);
            return this;
        }
    }
}
