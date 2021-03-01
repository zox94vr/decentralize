using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo
{
    public interface IAsyncQueryBuilder<T> where T:class
    {
        IAsyncQueryBuilder<T> Filter(Expression<Func<T, bool>> predicate);
        IAsyncQueryBuilder<T> JoinWith(Expression<Func<T, object>> join);
        Task<IList<T>> AsListAsync();
        Task<T> SingleResultAsync();



    }
}
