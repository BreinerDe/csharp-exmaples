using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Argument.Check;
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
            Context = context;
            entities = context.Set<T>();
        }
        public IAsyncEnumerable<T> GetAllAsync()
        {
            return entities.AsAsyncEnumerable();
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public IAsyncEnumerable<T> GetByAsync(Expression<Func<T, bool>> predicate)
        {
            return entities.Where(predicate).AsAsyncEnumerable();
        }
        public async Task<T> InsertAsync(T entity)
        {
            Throw.IfNull(() => entity);

            await entities.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            Throw.IfNull(() => entity);

            await Context.SaveChangesAsync();
            return entity;
        }
        public void Delete(Guid id)
        {
            var entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            Context.SaveChanges();
        }
    }
}