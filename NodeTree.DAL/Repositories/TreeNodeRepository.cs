using Microsoft.EntityFrameworkCore;
using NodeTree.DAL.Contexts;
using NodeTree.DAL.Entities;
using NodeTree.DAL.Repositories.Interfaces;

namespace NodeTree.DAL.Repositories
{
    public class TreeNodeRepository : BaseRepository<TreeNode>, ITreeNodeRepository
    {
        public TreeNodeRepository(NodeTreeDBContext dbContext) : base(dbContext) { }

        public async Task<TreeNode> GetEntireTreeAsync()
        {
            var rootNode = _dbSet.SingleOrDefaultAsync(n => n.ParentNodeId == null);

            if (rootNode == null)
            {

            }

            var allNodes = await _dbSet.ToListAsync();

            var nodesTree = allNodes.SingleOrDefault(n => n.ParentNodeId == null);

            return nodesTree;
        }

        public async Task<TreeNode> GetRootNodeByNameAsync(string rootName)
        {
            return await _dbSet.SingleOrDefaultAsync(n => n.Name == rootName && n.ParentNodeId == null);
        }
    }
}