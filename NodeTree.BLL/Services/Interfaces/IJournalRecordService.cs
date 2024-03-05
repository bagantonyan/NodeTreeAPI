using NodeTree.BLL.DTOs.JournalRecords;
using NodeTree.DAL.Entities;

namespace NodeTree.BLL.Services.Interfaces
{
    public interface IJournalRecordService
    {
        Task CreateAsync(JournalRecord requestDTO);
    }
}
