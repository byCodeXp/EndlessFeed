using DAL.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class PostConfiguration : EntityConfiguration<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            base.Configure(builder);
            
            builder
                .Property(post => post.Text)
                .IsRequired()
                .HasMaxLength(1024);

            // Relationship one to many
            builder
                .HasOne(post => post.Author)
                .WithMany(user => user.Posts);
            
            // Relationship one to one
            builder
                .HasOne(post => post.Publish)
                .WithOne(publish => publish.Post)
                .HasForeignKey<Publish>(publish => publish.PostId);
        }
    }
}