namespace NodeTree.API.Models.Journal
{
    public class JournalItemResponseModel
    {
        public long Id { get; set; }

        public string EventId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}