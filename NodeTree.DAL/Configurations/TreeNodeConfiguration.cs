using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NodeTree.DAL.Entities;

namespace NodeTree.DAL.Configurations
{
    public class TreeNodeConfiguration : BaseEntityConfiguration<TreeNode>
    {
        public override void Configure(EntityTypeBuilder<TreeNode> builder)
        {
            base.Configure(builder);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(256)
                .IsRequired(true);

            builder.HasOne(p => p.ParentNode)
                .WithMany(pn => pn.Children)
                .HasForeignKey(p => p.ParentNodeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => p.Name)
                .IsUnique(false);
        }
    }
}