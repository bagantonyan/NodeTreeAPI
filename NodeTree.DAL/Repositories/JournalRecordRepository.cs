using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NodeTree.DAL.Contexts;
using NodeTree.DAL.Entities;
using NodeTree.DAL.Repositories.Interfaces;
using NodeTree.Shared.RequestFeatures;

namespace NodeTree.DAL.Repositories
{
    public class JournalRecordRepository : BaseRepository<JournalRecord>, IJournalRecordRepository
    {
        public JournalRecordRepository(NodeTreeDBContext dbContext) : base(dbContext) { }

        public async Task<JournalRecord> GetByIdAsync(long recordId)
            => await GetByCondition(r => r.Id == recordId)
            .SingleOrDefaultAsync();

        public async Task<(IEnumerable<JournalRecord>, long)> GetRangeWithPagingAndFilterAsync(PagingModel paging, FilterModel filter)
        {
            var totalCount = await _dbSet.CountAsync();

            var query = _dbSet.AsQueryable();

            if (!filter.Search.IsNullOrEmpty())
                query = query.Where(r => r.Text.Contains(filter.Search));

            if (filter.From != default)
                query = query.Where(r => r.CreatedDate > filter.From);

            if (filter.To != default)
                query = query.Where(r => r.CreatedDate < filter.To);

            query = _dbSet
                .Skip(paging.Skip)
                .Take(paging.Take);

            return (await query
                .Select(r => new JournalRecord 
                { 
                    Id = r.Id, 
                    EventId = r.EventId, 
                    CreatedDate = r.CreatedDate 
                }).ToListAsync(), totalCount);
        }
    }
}