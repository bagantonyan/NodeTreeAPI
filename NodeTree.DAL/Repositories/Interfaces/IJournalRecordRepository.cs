using NodeTree.DAL.Entities;

namespace NodeTree.DAL.Repositories.Interfaces
{
    public interface IJournalRecordRepository : IBaseRepository<JournalRecord>
    {
        Task<JournalRecord> GetByIdAsync(long recordId);
    }
}
