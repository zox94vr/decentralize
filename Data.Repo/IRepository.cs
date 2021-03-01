using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repo
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T t);
        Task<T> DeleteAsync(T t);
        Task<T> UpdateAsync(T t);
        IAsyncQueryBuilder<T> DoQuery();
        Task<T> FindById(string id);
        Task<List<T>> GetAll(T t);
    }
}
