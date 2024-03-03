using NodeTree.DAL.Entities;

namespace NodeTree.DAL.Repositories.Interfaces
{
    public interface ITreeNodeRepository
    {
        Task<TreeNode> GetEntireTreeAsync();

        Task<TreeNode> GetRootNodeByNameAsync(string rootName);
    }
}