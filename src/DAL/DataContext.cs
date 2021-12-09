﻿using System;
using DAL.Configurations;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class DataContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new PostConfiguration());
        builder.ApplyConfiguration(new PublishConfiguration());
        builder.ApplyConfiguration(new CommentConfiguration());
        builder.ApplyConfiguration(new BlockPostConfiguration());
        builder.ApplyConfiguration(new BlockUserConfiguration());
        builder.ApplyConfiguration(new BlockCommentConfiguration());

        base.OnModelCreating(builder);
    }
    
    public DbSet<Post> Posts { get; set; }
    public DbSet<Publish> Publishes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
    public DbSet<BlockPost> BlockedPosts { get; set; }
    public DbSet<BlockUser> BlockedUsers { get; set; }
    public DbSet<BlockComment> BlockedComments { get; set; }
}