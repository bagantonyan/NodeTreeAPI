using NodeTree.DAL.Contexts;
using NodeTree.DAL.Repositories;
using NodeTree.DAL.Repositories.Interfaces;

namespace NodeTree.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NodeTreeDBContext _dbContext;
        private readonly ITreeNodeRepository _treeNodeRepository;
        private readonly IJournalRecordRepository _journalRecordRepository;

        public UnitOfWork(NodeTreeDBContext dbContext) => _dbContext = dbContext;

        public ITreeNodeRepository TreeNodeRepository
            => _treeNodeRepository is not null ? _treeNodeRepository : new TreeNodeRepository(_dbContext);

        public IJournalRecordRepository JournalRecordRepository
            => _journalRecordRepository is not null ? _journalRecordRepository : new JournalRecordRepository(_dbContext);

        public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

        public void Dispose() => _dbContext.Dispose();
    }
}