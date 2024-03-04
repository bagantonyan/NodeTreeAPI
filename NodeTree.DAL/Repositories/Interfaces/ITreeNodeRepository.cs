using NodeTree.DAL.Entities;

namespace NodeTree.DAL.Repositories.Interfaces
{
    public interface ITreeNodeRepository : IBaseRepository<TreeNode>
    {
        Task<TreeNode> GetByIdAsync(int treeNodeId);

        Task<TreeNode> GetRootNodeByNameAsync(string rootName);

        Task<IEnumerable<TreeNode>> GetChildrenNodes(int parentNodeId);

        Task<IEnumerable<TreeNode>> GetTreeNodesAsync(string rootName);
    }
}