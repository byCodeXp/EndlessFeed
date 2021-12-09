using System;

namespace API.Dtos;

public record CommentDto
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }
}