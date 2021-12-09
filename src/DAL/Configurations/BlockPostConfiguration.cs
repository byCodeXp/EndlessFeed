using DAL.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class BlockPostConfiguration : EntityConfiguration<BlockPost>
{
    public override void Configure(EntityTypeBuilder<BlockPost> builder)
    {
        base.Configure(builder);
        
        // Relationship one to one
        builder
            .HasOne(blockPublish => blockPublish.Post)
            .WithOne(post => post.BlockPost)
            .HasForeignKey<BlockPost>(blockPublish => blockPublish.PostId);
    }
}