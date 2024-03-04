using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NodeTree.DAL.Contexts;
using NodeTree.DAL.Entities;
using NodeTree.DAL.Repositories.Interfaces;

namespace NodeTree.DAL.Repositories
{
    public class TreeNodeRepository : BaseRepository<TreeNode>, ITreeNodeRepository
    {
        public TreeNodeRepository(NodeTreeDBContext dbContext) : base(dbContext) { }

        public async Task<TreeNode> GetByIdAsync(int treeNodeId)
            => await GetByCondition(n => n.Id == treeNodeId)
            .AsNoTrackingWithIdentityResolution()
            .SingleOrDefaultAsync();

        public async Task<TreeNode> GetRootNodeByNameAsync(string rootName)
            => await GetByCondition(n => n.Name == rootName && n.ParentNodeId == null)
            .AsNoTrackingWithIdentityResolution()
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<TreeNode>> GetChildrenNodes(int parentNodeId)
            => await GetByCondition(n => n.Id == parentNodeId)
            .AsNoTrackingWithIdentityResolution()
            .Include(n => n.Children)
            .ToListAsync();

        public async Task<IEnumerable<TreeNode>> GetTreeNodesAsync(string rootName)
            => await _dbSet.FromSqlRaw($"[dbo].[spGetNodeTree] @rootName", new SqlParameter("@rootName", rootName))
            .IgnoreQueryFilters()
            .AsNoTrackingWithIdentityResolution()
            .ToListAsync();
    }
}