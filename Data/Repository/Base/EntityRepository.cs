using Data.EF;
using Data.Identity.Repository.Base;
using Domain.Entity.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repository.Base
{
    public abstract class EntityRepository<TEntity> : IEntityRepository<TEntity>
             where TEntity : EntityBase
    {
        protected EntityRepository(LandSellingContext dbContext)
        {
            _DbContext = dbContext;
        }

        protected internal LandSellingContext _DbContext { get; set; }

        public async Task<Guid> Add(TEntity entity)
        {
            var newEntity = await _DbContext.Set<TEntity>().AddAsync(entity);
            await _DbContext.SaveChangesAsync();
            return newEntity.Entity.Id;
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> expression)
        {
            return await _DbContext.Set<TEntity>().Where(expression).ToListAsync();
        }

        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            return await _DbContext.Set<TEntity>().FirstOrDefaultAsync(expression);

        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _DbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _DbContext.Set<TEntity>().FirstAsync(e => e.Id == id);
        }

        public Task Remove(TEntity entity)
        {
            return Task.FromResult(_DbContext.Set<TEntity>().Remove(entity));
        }

        public Task Update(TEntity entity)
        {
            return Task.FromResult(_DbContext.Set<TEntity>().Update(entity));
        }
    }
}
