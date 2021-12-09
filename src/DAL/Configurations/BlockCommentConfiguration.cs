using DAL.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class BlockCommentConfiguration : EntityConfiguration<BlockComment>
{
    public override void Configure(EntityTypeBuilder<BlockComment> builder)
    {
        base.Configure(builder);

        // Relationship one to one
        builder
            .HasOne(blockComment => blockComment.Comment)
            .WithOne(comment => comment.BlockComment)
            .HasForeignKey<BlockComment>(blockComment => blockComment.CommentId);
    }
}