using NodeTree.DAL.Contexts;
using NodeTree.DAL.Entities;
using NodeTree.DAL.Repositories.Interfaces;

namespace NodeTree.DAL.Repositories
{
    public class JournalRecordRepository : BaseRepository<JournalRecord>, IJournalRecordRepository
    {
        public JournalRecordRepository(NodeTreeDBContext dbContext) : base(dbContext) { }
    }
}