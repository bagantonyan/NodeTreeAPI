namespace NodeTree.API.Models.TreeNode
{
    public class CreateNodeRequestModel
    {
        public string TreeName { get; set; }

        public int ParentNodeId { get; set; }

        public string NodeName { get; set; }
    }
}