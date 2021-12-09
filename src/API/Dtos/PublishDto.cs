using System;

namespace API.Dtos;

public record PublishDto
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public UserDto Author { get; set; }
    public DateTime PublishedAt { get; set; }
};