using NodeTree.DAL.Entities;
using NodeTree.Shared.RequestFeatures;

namespace NodeTree.DAL.Repositories.Interfaces
{
    public interface IJournalRecordRepository : IBaseRepository<JournalRecord>
    {
        Task<JournalRecord> GetByIdAsync(long recordId);

        Task<(IEnumerable<JournalRecord>, long)> GetRangeWithPagingAndFilterAsync(PagingModel paging, FilterModel filter);
    }
}