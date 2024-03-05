using NodeTree.BLL.DTOs.JournalRecords;
using NodeTree.DAL.Entities;

namespace NodeTree.BLL.Services.Interfaces
{
    public interface IJournalRecordService
    {
        Task<JournalRecordDTO> GetByIdAsync(long recordId);

        Task CreateAsync(JournalRecord journalRecord);

        Task UpdateAsync(JournalRecord journalRecord);
    }
}