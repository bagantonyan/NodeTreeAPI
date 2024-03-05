namespace NodeTree.API.Models.TreeNode
{
    public class RenameNodeRequestModel
    {
        public string TreeName { get; set; }

        public int NodeId { get; set; }

        public string NewNodeName { get; set; }
    }
}