using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Contracts.Requests.v1;
using API.Dtos;
using API.Exceptions;
using DAL;
using DAL.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace API.Services.v1
{
    public class PostsServiceV1
    {
        private readonly DataContext _context;

        public PostsServiceV1(DataContext context)
        {
            _context = context;
        }

        private int CalculateOffset(int page, int perPage) => page <= 0 ? 1 : page * perPage - perPage;
        
        public IEnumerable<PostDto> GetPublishedPosts(GetPublishesRequestV1 requestV1)
        {
            int skip = CalculateOffset(requestV1.Page, requestV1.PerPage);
            int take = requestV1.PerPage;
            
            IEnumerable<Post> posts = _context.Publishes
                .Include(publish => publish.Post)
                .OrderByDescending(publish => publish.CreatedTimeStamp)
                .Skip(skip)
                .Take(take)
                .Select(publish => publish.Post);

            return posts.Adapt<IEnumerable<PostDto>>();
        }

        public async Task<PostDto> GetTopPostAsync(Guid userId)
        {
            User user = await _context.Users.FindAsync(userId);

            if (user is null)
            {
                throw new BadRequestRestException("User does not exists");
            }

            var post = await _context.Posts.OrderBy(post => post.CreatedTimeStamp).LastOrDefaultAsync();

            if (post is null)
            {
                throw new BadRequestRestException("Post does not exists");
            }
            
            return post.Adapt<PostDto>();
        }
        
        public async Task<PostDto> CreateAsync(Guid userId, CreatePostRequestV1 requestV1)
        {
            User user = await _context.Users.FindAsync(userId);

            if (user is null)
            {
                throw new BadRequestRestException("User does not exists");
            }
            
            var post = new Post
            {
                Text = requestV1.Text,
                Author = user
            };
            
            await _context.Posts.AddAsync(post);
            
            await _context.SaveChangesAsync();

            return post.Adapt<PostDto>();
        }

        public async Task UpdateAsync(Guid userId, UpdatePostRequestV1 requestV1)
        {
            User user = await _context.Users.FindAsync(userId);

            if (user is null)
            {
                throw new BadRequestRestException("User does not exists");
            }

            await _context.Entry(user).Collection(u => u.Posts).LoadAsync();
            
            var post = user.Posts.FirstOrDefault(post => post.Id == requestV1.Id);

            if (post is null)
            {
                throw new BadRequestRestException("Post does not exists");
            }

            post.Text = requestV1.Text;
            
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid userId, Guid postId)
        {
            User user = await _context.Users.FindAsync(userId);

            if (user is null)
            {
                throw new BadRequestRestException("User does not exists");
            }
            
            await _context.Entry(user).Collection(u => u.Posts).LoadAsync();
            
            var post = user.Posts.FirstOrDefault(post => post.Id == postId);

            if (post is null)
            {
                throw new BadRequestRestException("Post does not exists");
            }

            if (!user.Posts.Contains(post))
            {
                throw new BadRequestRestException("Post does not exists");
            }
            
            _context.Posts.Remove(post);
            
            await _context.SaveChangesAsync();
        }

        public async Task PublishAsync(Guid postId)
        {
            Post post = await _context.Posts.FindAsync(postId);
            
            if (post is null)
            {
                throw new BadRequestRestException("Post does not exists");
            }

            var publish = new Publish
            {
                Post = post
            };

            await _context.AddAsync(publish);

            await _context.SaveChangesAsync();
        }
    }
}