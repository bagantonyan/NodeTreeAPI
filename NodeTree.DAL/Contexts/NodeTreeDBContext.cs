using Microsoft.EntityFrameworkCore;
using NodeTree.DAL.Configurations;
using NodeTree.DAL.Entities;
using NodeTree.DAL.Extensions;

namespace NodeTree.DAL.Contexts
{
    public class NodeTreeDBContext(DbContextOptions<NodeTreeDBContext> options) : DbContext(options)
    {
        public DbSet<TreeNode> TreeNodes { get; set; }

        public DbSet<JournalRecord> JournalRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<long>("EventId");

            modelBuilder.ApplyConfiguration(new TreeNodeConfiguration());
            modelBuilder.ApplyConfiguration(new JournalRecordConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.SetAuditProperties();

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}