using System;
using DAL.Entities.Base;

namespace DAL.Entities;

public class BlockUser : Entity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
}