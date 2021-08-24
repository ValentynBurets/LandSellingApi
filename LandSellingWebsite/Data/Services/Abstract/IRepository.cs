using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LandSellingWebsite.Data.Services.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetById(object id, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> Add(TEntity fuel);

        Task<TEntity> Update(TEntity fuel);

        Task Delete(object id);

        bool Exist(Expression<Func<TEntity, bool>> predicate);

    }
}