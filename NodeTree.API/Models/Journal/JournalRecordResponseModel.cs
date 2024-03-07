namespace NodeTree.API.Models.Journal
{
    public class JournalRecordResponseModel
    {
        public long Id { get; set; }

        public string EventId { get; set; }

        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}