namespace NodeTree.BLL.DTOs.TreeNodes
{
    public class CreateTreeNodeRequestDTO
    {
        public string TreeName { get; set; }

        public int ParentNodeId { get; set; }

        public string NodeName { get; set; }
    }
}