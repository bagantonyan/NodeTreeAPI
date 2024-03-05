namespace NodeTree.BLL.DTOs.TreeNodes
{
    public class TreeResponseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<TreeResponseDTO> Children { get; set; }
    }
}
