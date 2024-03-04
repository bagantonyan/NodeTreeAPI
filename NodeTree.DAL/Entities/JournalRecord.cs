namespace NodeTree.DAL.Entities
{
    public class JournalRecord : BaseEntity
    {
        public long Id { get; set; }

        public long EventId { get; set; }

        public string Text { get; set; }
    }
}