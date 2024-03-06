using NodeTree.BLL.DTOs.JournalRecords;
using NodeTree.DAL.Entities;
using NodeTree.Shared.RequestFeatures;

namespace NodeTree.BLL.Services.Interfaces
{
    public interface IJournalRecordService
    {
        Task<JournalRecordDTO> GetByIdAsync(long recordId);

        Task<(IEnumerable<JournalRecordDTO>, long)> GetRangeWithPagingAndFilterAsync(PagingModel paging, FilterModel filter);

        Task CreateAsync(JournalRecord journalRecord);

        Task UpdateAsync(JournalRecord journalRecord);
    }
}