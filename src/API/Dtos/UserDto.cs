using System;

namespace API.Dtos;

public record UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Photo { get; set; }
    public string UserName { get; set; }
}