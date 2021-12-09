using System;
using System.Linq;
using System.Threading.Tasks;
using API.Contracts.Requests.v1;
using API.Dtos;
using API.Exceptions;
using API.Services.Base;
using DAL;
using DAL.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.v1;

public class CommentsServiceV1 : Service
{
    public CommentsServiceV1(DataContext context)
    {
        Context = context;
    }
    
    public async Task<CommentDto> CreateCommentAsync(CreateCommentRequestV1 request, Guid userId)
    {
        // TODO: check if post published then create comment
            
        User user = await Context.Users.FindAsync(userId);

        if (user is null)
        {
            throw new BadRequestRestException("User does not exists");
        }

        await Context.Entry(user).Collection(c => c.Posts).LoadAsync();

        var post = user.Posts.FirstOrDefault(m => m.Id == request.PostId);

        if (post is null)
        {
            throw new BadRequestRestException("Post does not exists");
        }
            
        var comment = new Comment
        {
            Text = request.Text,
            Post = post,
            Author = user
        };

        await Context.Comments.AddAsync(comment);

        await Context.SaveChangesAsync();

        return comment.Adapt<CommentDto>();
    }

    public async Task UpdateCommentAsync(UpdateCommentRequestV1 request, Guid userId)
    {
        // TODO: check if post published then create comment
            
        User user = await Context.Users.FindAsync(userId);

        if (user is null)
        {
            throw new BadRequestRestException("User does not exists");
        }
            
        await Context.Entry(user).Collection(c => c.Comments).LoadAsync();
            
        var comment = user.Comments.FirstOrDefault(m => m.Id == request.CommentId);

        if (comment is null)
        {
            throw new BadRequestRestException("Comment does not exists");
        }

        comment.Text = request.Text;
            
        await Context.SaveChangesAsync();
    }

    public async Task DeleteCommentAsync(Guid commentId, Guid userId)
    {
        // TODO: check if post published then create comment
            
        User user = await Context.Users.FindAsync(userId);

        if (user is null)
        {
            throw new BadRequestRestException("User does not exists");
        }
            
        await Context.Entry(user).Collection(c => c.Comments).LoadAsync();
            
        var comment = user.Comments.FirstOrDefault(m => m.Id == commentId);

        if (comment is null)
        {
            throw new BadRequestRestException("Comment does not exists");
        }

        Context.Remove(comment);
            
        await Context.SaveChangesAsync();
    }

    public async Task BlockCommentByIdAsync(Guid commentId)
    {
        var comment = await Context.Comments.FindAsync(commentId);

        if (comment is null)
        {
            throw new BadRequestRestException("Comment does not exists");
        }

        var blockComment = new BlockComment
        {
            Comment = comment
        };

        await Context.BlockedComments.AddAsync(blockComment);

        await Context.SaveChangesAsync();
    }
}