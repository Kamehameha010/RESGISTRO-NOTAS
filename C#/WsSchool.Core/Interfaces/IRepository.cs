using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WsSchool.Core.Interfaces
{
#nullable enable
    public interface IRepository<TEntity>
    {
        void Insert(TEntity entity);
        Task Update(int id, TEntity entity);
        Task<TEntity>? GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Delete(int id);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>>? filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy);
    }
#nullable disable
}
