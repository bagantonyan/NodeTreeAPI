using NodeTree.DAL.Entities;

namespace NodeTree.DAL.Repositories.Interfaces
{
    public interface ITreeNodeRepository : IBaseRepository<TreeNode>
    {
        Task<TreeNode> GetByIdAsync(int treeNodeId, bool trackChanges = false, bool includeChildren = false);

        Task<TreeNode> GetRootNodeByNameAsync(string rootName);

        Task<IEnumerable<TreeNode>> GetTreeNodesAsync(string rootName);
    }
}