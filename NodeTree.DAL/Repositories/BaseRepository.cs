using Microsoft.EntityFrameworkCore;
using NodeTree.DAL.Contexts;
using NodeTree.DAL.Entities;
using NodeTree.DAL.Repositories.Interfaces;
using System.Linq.Expressions;

namespace NodeTree.DAL.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(NodeTreeDBContext dbContext) => _dbSet = dbContext.Set<TEntity>();

        public void Create(TEntity entity) 
            => _dbSet.Add(entity);

        public void Update(TEntity entity) 
            => _dbSet.Update(entity);

        public void Delete(TEntity entity) 
            => _dbSet.Remove(entity);

        public IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression)
            => _dbSet.Where(expression);
    }
}