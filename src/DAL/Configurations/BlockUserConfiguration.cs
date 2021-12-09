using DAL.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class BlockUserConfiguration : EntityConfiguration<BlockUser>
{
    public override void Configure(EntityTypeBuilder<BlockUser> builder)
    {
        base.Configure(builder);
        
        // Relationship one to one
        builder
            .HasOne(blockUser => blockUser.User)
            .WithOne(user => user.BlockUser)
            .HasForeignKey<BlockUser>(blockUser => blockUser.UserId);
    }
}