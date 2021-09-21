using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WsSchool.Core.Interfaces;

namespace WsSchool.Core.Repository
{
#nullable enable
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _entities;
        public GenericRepository(DbContext context)
        {
            _entities = context.Set<TEntity>();
        }
        public void Insert(TEntity entity) => _entities.Add(entity);
        public async Task Update(int id, TEntity entity)
        {
            var oEntity = await _entities.FindAsync(id);
            _entities.Remove(oEntity);
            _entities.Add(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll() => await _entities.ToListAsync();
        public async Task<TEntity>? GetById(int id) => await _entities.FindAsync(id);
        public async Task Delete(int id)
        {
            var oEntity = await _entities.FindAsync(id);
            if (oEntity != null)
            {
                _entities.Remove(oEntity);
            }
            throw new NullReferenceException();
        }
        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>>? filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy)
        {
            IQueryable<TEntity> query = _entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }

    }
#nullable disable
}
