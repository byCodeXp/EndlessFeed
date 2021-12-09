using System;
using DAL.Entities.Base;

namespace DAL.Entities;

public class BlockComment : Entity
{
    public Guid CommentId { get; set; }
    public Comment Comment { get; set; }
}