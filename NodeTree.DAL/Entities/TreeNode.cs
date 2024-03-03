namespace NodeTree.DAL.Entities
{
    public class TreeNode : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentNodeId { get; set; }

        public TreeNode? ParentNode { get; set; }

        public ICollection<TreeNode> Children { get; } = new List<TreeNode>();
    }
}