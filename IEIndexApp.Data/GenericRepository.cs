using IEIndexApp.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IEIndexApp.Data
{
    public class GenericRepository<TEntity> where TEntity : Entity
    {
        internal DbContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> All() => _dbSet.AsNoTracking().ToList();
       
        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate) => 
            _dbSet.AsNoTracking().Where(predicate).ToList();       

        public TEntity FindByKey(int id) => _dbSet.AsNoTracking().SingleOrDefault(x => x.Id == id);        

        public void Insert(TEntity entity) => _dbSet.Add(entity);        

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id) => _dbSet.Remove(FindByKey(id));       
    }
}
