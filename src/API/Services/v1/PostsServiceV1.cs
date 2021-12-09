using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Contracts.Requests.v1;
using API.Dtos;
using API.Exceptions;
using API.Services.Base;
using DAL;
using DAL.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace API.Services.v1;

public class PostsServiceV1 : Service
{
    public PostsServiceV1(DataContext context)
    {
        Context = context;
    }

    private int CalculateOffset(int page, int perPage) => page <= 0 ? 1 : page * perPage - perPage;
        
    public IEnumerable<PostDto> GetPublishedPosts(GetPostsRequestV1 request)
    {
        int skip = CalculateOffset(request.Page, request.PerPage);
        int take = request.PerPage;

        IEnumerable<PostDto> posts = Context.Publishes
            .Include(publish => publish.Post)
            .ThenInclude(post => post.Author)
            .OrderByDescending(publish => publish.CreatedTimeStamp)
            .Skip(skip)
            .Take(take)
            .Select(publish => publish.Post)
            .ProjectToType<PostDto>();

        return posts;
    }
    
    public IEnumerable<PostDto> GetPosts(GetPostsRequestV1 request)
    {
        int skip = CalculateOffset(request.Page, request.PerPage);
        int take = request.PerPage;

        IEnumerable<PostDto> posts = Context.Posts
            .Include(post => post.Author)
            .OrderByDescending(post => post.CreatedTimeStamp)
            .Skip(skip)
            .Take(take)
            .ProjectToType<PostDto>();
        
        return posts;
    }

    public async Task<IEnumerable<CommentDto>> GetPublishedPostComments(Guid publishId)
    {
        var publish = await Context.Publishes.FindAsync(publishId);

        if (publish is null)
        {
            throw new BadRequestRestException("Publish does not exists");
        }
        
        var post = await Context.Posts.FindAsync(publish.PostId);

        if (post is null)
        {
            throw new BadRequestRestException("Post does not exists");
        }

        await Context.Entry(post).Collection(post => post.Comments).LoadAsync();

        return post.Comments.Adapt<IEnumerable<CommentDto>>();
    }
    
    public async Task<PostDto> GetCurrentPostAsync(Guid userId)
    {
        User user = await Context.Users.FindAsync(userId);

        if (user is null)
        {
            throw new BadRequestRestException("User does not exists");
        }

        var post = await Context.Posts.OrderBy(post => post.CreatedTimeStamp).LastOrDefaultAsync();

        if (post is null)
        {
            throw new BadRequestRestException("Post does not exists");
        }
            
        return post.Adapt<PostDto>();
    }
    
    public async Task<PostDto> CreateAsync(Guid userId, CreatePostRequestV1 request)
    {
        User user = await Context.Users.FindAsync(userId);

        if (user is null)
        {
            throw new BadRequestRestException("User does not exists");
        }
            
        var post = new Post
        {
            Text = request.Text,
            Author = user
        };
            
        await Context.Posts.AddAsync(post);
            
        await Context.SaveChangesAsync();

        return post.Adapt<PostDto>();
    }

    public async Task UpdateAsync(Guid userId, UpdatePostRequestV1 request)
    {
        User user = await Context.Users.FindAsync(userId);

        if (user is null)
        {
            throw new BadRequestRestException("User does not exists");
        }

        await Context.Entry(user).Collection(u => u.Posts).LoadAsync();
            
        var post = user.Posts.FirstOrDefault(post => post.Id == request.Id);

        if (post is null)
        {
            throw new BadRequestRestException("Post does not exists");
        }

        post.Text = request.Text;
            
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid userId, Guid postId)
    {
        User user = await Context.Users.FindAsync(userId);

        if (user is null)
        {
            throw new BadRequestRestException("User does not exists");
        }
            
        await Context.Entry(user).Collection(u => u.Posts).LoadAsync();
            
        var post = user.Posts.FirstOrDefault(post => post.Id == postId);

        if (post is null)
        {
            throw new BadRequestRestException("Post does not exists");
        }

        if (!user.Posts.Contains(post))
        {
            throw new BadRequestRestException("Post does not exists");
        }
            
        Context.Posts.Remove(post);
            
        await Context.SaveChangesAsync();
    }

    public async Task PublishAsync(Guid postId)
    {
        Post post = await Context.Posts.FindAsync(postId);
            
        if (post is null)
        {
            throw new BadRequestRestException("Post does not exists");
        }

        var publish = new Publish
        {
            Post = post
        };

        await Context.AddAsync(publish);

        await Context.SaveChangesAsync();
    }
}