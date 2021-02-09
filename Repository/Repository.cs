using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GenericRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext Context;
        private readonly DbSet<T> entities;
        public Repository(DbContext context)
        {
            this.Context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T GetById(Guid id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            return entities.Where(predicate);
        }

        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entities.Add(entity);
            Context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            Context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            if (id == null) throw new ArgumentNullException("entity");

            var entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            Context.SaveChanges();
        }

    }
}