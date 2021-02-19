using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GenericRepository.Models;

namespace GenericRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IAsyncEnumerable<T> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        void Delete(Guid id);
        IAsyncEnumerable<T> GetByAsync(Expression<Func<T, bool>> predicate);
    }
}