using NodeTree.DAL.Entities;

namespace NodeTree.DAL.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}