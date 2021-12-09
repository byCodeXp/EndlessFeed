using System;
using System.Linq;
using System.Threading.Tasks;
using API.Contracts.Requests.v1;
using API.Dtos;
using API.Exceptions;
using DAL;
using DAL.Entities;
using Mapster;

namespace API.Services.v1;

public class CommentsServiceV1
{
    private readonly DataContext _context;

    public CommentsServiceV1(DataContext context)
    {
        _context = context;
    }
        
    public async Task<CommentDto> CreateCommentAsync(CreateCommentRequestV1 request, Guid userId)
    {
        // TODO: check if post published then create comment
            
        User user = await _context.Users.FindAsync(userId);

        if (user is null)
        {
            throw new BadRequestRestException("User does not exists");
        }

        await _context.Entry(user).Collection(c => c.Posts).LoadAsync();

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

        await _context.Comments.AddAsync(comment);

        await _context.SaveChangesAsync();

        return comment.Adapt<CommentDto>();
    }

    public async Task UpdateCommentAsync(UpdateCommentRequestV1 request, Guid userId)
    {
        // TODO: check if post published then create comment
            
        User user = await _context.Users.FindAsync(userId);

        if (user is null)
        {
            throw new BadRequestRestException("User does not exists");
        }
            
        await _context.Entry(user).Collection(c => c.Comments).LoadAsync();
            
        var comment = user.Comments.FirstOrDefault(m => m.Id == request.CommentId);

        if (comment is null)
        {
            throw new BadRequestRestException("Comment does not exists");
        }

        comment.Text = request.Text;
            
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCommentAsync(Guid commentId, Guid userId)
    {
        // TODO: check if post published then create comment
            
        User user = await _context.Users.FindAsync(userId);

        if (user is null)
        {
            throw new BadRequestRestException("User does not exists");
        }
            
        await _context.Entry(user).Collection(c => c.Comments).LoadAsync();
            
        var comment = user.Comments.FirstOrDefault(m => m.Id == commentId);

        if (comment is null)
        {
            throw new BadRequestRestException("Comment does not exists");
        }

        _context.Remove(comment);
            
        await _context.SaveChangesAsync();
    }
}