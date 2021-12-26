using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Core.Interfaces;
using SchoolSystem.Infrastructure.Data;

namespace SchoolSystem.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly SchoolDBContext _context;
        private readonly DbSet<TEntity> _entities;
        public BaseRepository(SchoolDBContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity model) => await _entities.AddAsync(model);


        public async Task DeleteAsync(int id)
        {
            var oEntity = await FindAsync(id);
            if (oEntity != null)
            {
                _entities.Remove(oEntity);
            }
            throw new NullReferenceException();
        }

        public async Task<TEntity> FindAsync(int id) => await _entities.FindAsync(id);

        public IEnumerable<TEntity> GetAll() => _entities.AsEnumerable();

        public void Update(TEntity model) => _entities.Update(model);
    }
}