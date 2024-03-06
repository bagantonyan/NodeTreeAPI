using System.ComponentModel.DataAnnotations;

namespace NodeTree.Shared.RequestFeatures
{
    public class PagingModel
    {
        [Required]
        public int Skip { get; set; }

        [Required]
        public int Take { get; set; }
    }
}