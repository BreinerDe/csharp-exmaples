using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GenericRepository.Models;

namespace GenericRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(Guid id);
        IEnumerable<T> GetBy(Expression<Func<T, bool>> predicate);
    }
}