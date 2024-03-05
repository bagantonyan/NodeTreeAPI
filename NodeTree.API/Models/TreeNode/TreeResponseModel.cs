namespace NodeTree.API.Models.TreeNode
{
    public class TreeResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<TreeResponseModel> Children { get; set; }
    }
}
