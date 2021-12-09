﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entities;

public class User : IdentityUser<Guid>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Photo { get; set; }
    public DateTime Birthday { get; set; }
    public BlockUser BlockUser { get; set; }
    public List<Post> Posts { get; set; }
    public List<Comment> Comments { get; set; }
    public DateTime CreatedTimeStamp { get; set; }
    public DateTime UpdatedTimeStamp { get; set; }
}