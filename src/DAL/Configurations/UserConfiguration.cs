using System;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(entity => entity.CreatedTimeStamp)
            .HasDefaultValue(DateTime.UtcNow)
            .ValueGeneratedOnAdd();
            
        builder
            .Property(entity => entity.UpdatedTimeStamp)
            .HasDefaultValue(DateTime.UtcNow)
            .ValueGeneratedOnAddOrUpdate();
            
        // Relationships one to many
        builder
            .HasMany(user => user.Posts)
            .WithOne(post => post.Author);
        
        // Relationship one to one
        builder
            .HasOne(user => user.BlockUser)
            .WithOne(blockUser => blockUser.User)
            .HasForeignKey<BlockUser>(blockUser => blockUser.UserId);
    }
}