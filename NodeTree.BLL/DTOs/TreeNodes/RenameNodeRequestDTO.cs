namespace NodeTree.BLL.DTOs.TreeNodes
{
    public class RenameNodeRequestDTO
    {
        public string TreeName { get; set; }

        public int NodeId { get; set; }

        public string NewNodeName { get; set; }
    }
}