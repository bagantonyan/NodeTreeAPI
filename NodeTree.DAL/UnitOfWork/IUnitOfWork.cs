using NodeTree.DAL.Repositories.Interfaces;

namespace NodeTree.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ITreeNodeRepository TreeNodeRepository { get; }
        Task SaveChangesAsync();
    }
}