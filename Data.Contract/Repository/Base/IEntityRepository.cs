﻿using Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Identity.Repository.Base
{
    public interface IEntityRepository<TEntity>
        where TEntity : EntityBase
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetById(Guid id);
        Task<Guid> Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
    }
}
