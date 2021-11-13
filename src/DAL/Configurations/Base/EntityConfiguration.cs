using System;
using DAL.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations.Base
{
    public class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder
                .Property(entity => entity.CreatedTimeStamp)
                .HasDefaultValue(DateTime.UtcNow)
                .ValueGeneratedOnAdd();
            builder
                .Property(entity => entity.UpdatedTimeStamp)
                .HasDefaultValue(DateTime.UtcNow)
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}