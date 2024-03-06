namespace NodeTree.API.Models.Journal
{
    public class JournalListResponseModel
    {
        public int Skip { get; set; }

        public long Count { get; set; }

        public List<JournalItemResponseModel> Items { get; set; }
    }
}