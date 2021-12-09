using DAL.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class PublishConfiguration : EntityConfiguration<Publish>
{
    public override void Configure(EntityTypeBuilder<Publish> builder)
    {
        // Relationship one to one
        builder
            .HasOne(publish => publish.Post)
            .WithOne(post => post.Publish)
            .HasForeignKey<Publish>(publish => publish.PostId);
    }
}