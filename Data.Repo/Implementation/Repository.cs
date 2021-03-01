using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Repo.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected Context _context { get; set; }
        public Repository(Context context)
        {
            _context = context;
        }
        public virtual async Task<T> AddAsync(T t)
        {
            if (t == null)
            {
                throw new ArgumentNullException($"You provide null instead of object");
            }
            try
            {
                await _context.AddAsync(t);
                await _context.SaveChangesAsync();
                return t;
            }
            catch (Exception ex)
            {

                throw new Exception("Coudn't Add: " + ex.Message);
            }
        }

        public virtual async Task<T> DeleteAsync(T t)
        {
            if (t == null)
            {
                throw new ArgumentNullException($"You provide null instead of object");
            }
            try
            {
                _context.Remove(t);
                await _context.SaveChangesAsync();
                return t;
            }
            catch (Exception ex)
            {

                throw new Exception("Coudn't delete: " + ex.Message);
            }
        }



        public virtual async Task<T> UpdateAsync(T t)
        {
            if (t == null)
            {
                throw new ArgumentNullException($"You provide null instead of object");
            }
            try
            {
                _context.Update(t);
                await _context.SaveChangesAsync();
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception("Coudn't update: " + ex.Message);
            }
        }

        //public virtual IQueryable<T> Where(Expression<Func<T, bool>> pred)
        //{
        //    try
        //    {
        //        return _context.Set<T>().Where(pred);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception($"Problem in executing Where: " + ex.Message);
        //    }
        //}



        public virtual Task<T> FindById(string t)
        {
            throw new NotImplementedException();
        }
        public async Task<List<T>> GetAll(T t)=> await _context.Set<T>().ToListAsync();
        public IAsyncQueryBuilder<T> DoQuery()  => new AsyncQueryBuilder<T>(_context.Set<T>().AsQueryable());


    }
}
