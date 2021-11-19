﻿using System;
using System.Linq;
using System.Threading.Tasks;
using API.Contracts.Requests;
using API.Dtos;
using API.Exceptions;
using DAL;
using DAL.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class PostsService
    {
        private readonly DataContext _context;

        public PostsService(DataContext context)
        {
            _context = context;
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
        
        public async Task<PostDto> CreateAsync(Guid userId, CreatePostRequest request)
        {
            User user = await _context.Users.FindAsync(userId);

            if (user is null)
            {
                throw new BadRequestRestException("User does not exists");
            }
            
            var post = new Post
            {
                Text = request.Text,
                Author = user
            };
            
            await _context.Posts.AddAsync(post);
            
            await _context.SaveChangesAsync();

            return post.Adapt<PostDto>();
        }

        public async Task UpdateAsync(Guid userId, UpdatePostRequest request)
        {
            User user = await _context.Users.FindAsync(userId);

            if (user is null)
            {
                throw new BadRequestRestException("User does not exists");
            }

            await _context.Entry(user).Collection(u => u.Posts).LoadAsync();
            
            var post = user.Posts.FirstOrDefault(post => post.Id == request.Id);

            if (post is null)
            {
                throw new BadRequestRestException("Post does not exists");
            }

            post.Text = request.Text;
            
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
    }
}