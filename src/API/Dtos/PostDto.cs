using System;

namespace API.Dtos
{
    public class PostDto
    {
        public Guid Id { get; set; } 
        public string Text { get; set; }
        public UserDto Author { get; set; }
        // TODO: add field published at
    }
}