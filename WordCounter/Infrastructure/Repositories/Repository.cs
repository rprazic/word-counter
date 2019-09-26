using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WordCounter.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity>
            where TEntity : class, IEntity
    {
        protected readonly DbContext _context;

        protected readonly DbSet<TEntity> _entities;

        public Repository(DbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public virtual bool Any()
        {
            return _entities.Any();
        }

        public virtual async Task<bool> AnyAsync()
        {
            return await _entities.AnyAsync();
        }

        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        public virtual void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

        public virtual int Count()
        {
            return _entities.Count();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return GetEntities()
                .Where(predicate);
        }

        public virtual TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return GetEntities()
                .SingleOrDefault(predicate);
        }

        protected virtual IQueryable<TEntity> GetEntities()
        {
            return _entities;
        }

        public virtual TEntity Get(int id)
        {
            return GetEntities()
                .Where(entity => entity.Id.Equals(id))
                .SingleOrDefault();
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await GetEntities()
                .Where(entity => entity.Id.Equals(id))
                .SingleOrDefaultAsync();
        }

        public virtual List<TEntity> GetAll()
        {
            return GetEntities()
                .ToList();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await GetEntities()
                .ToListAsync();
        }
    }
}
