using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NodeTree.DAL.Entities;

namespace NodeTree.DAL.Configurations
{
    public class JournalRecordConfiguration : BaseEntityConfiguration<JournalRecord>
    {
        public override void Configure(EntityTypeBuilder<JournalRecord> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.Property(p => p.EventId)
                .HasDefaultValueSql("NEXT VALUE FOR EventId")
                .IsRequired(true);

            builder.Property(p => p.Text)
                .IsRequired(true);
        }
    }
}