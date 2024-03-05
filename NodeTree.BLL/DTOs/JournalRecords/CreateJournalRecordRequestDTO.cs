namespace NodeTree.BLL.DTOs.JournalRecords
{
    public class CreateJournalRecordRequestDTO
    {
        public long Id { get; set; }

        public long EventId { get; set; }

        public string Text { get; set; }
    }
}
