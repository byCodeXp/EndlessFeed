using DAL.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class CommentConfiguration : EntityConfiguration<Comment>
{
    public override void Configure(EntityTypeBuilder<Comment> builder)
    {
        base.Configure(builder);

        builder
            .Property(m => m.Text)
            .IsRequired()
            .HasMaxLength(1024);

        // Relationship one to many
        builder
            .HasOne(m => m.Author)
            .WithMany(c => c.Comments);
            
        // Relationship one to many
        builder
            .HasOne(m => m.Author)
            .WithMany(c => c.Comments);
        
        // Relationship one to one
        builder
            .HasOne(comment => comment.BlockComment)
            .WithOne(blockComment => blockComment.Comment)
            .HasForeignKey<BlockComment>(blockComment => blockComment.CommentId);
    }
}