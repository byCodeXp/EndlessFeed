﻿using System.Collections.Generic;
using DAL.Entities.Base;

namespace DAL.Entities;

public class Post : Entity
{
    public string Text { get; set; }
    public User Author { get; set; }
    public Publish Publish { get; set; }
    public BlockPost BlockPost { get; set; }
    public List<Comment> Comments { get; set; }
}