using System;

namespace DAL.Entities.Base;

public class Entity
{
    public Guid Id { get; set; }
    public DateTime CreatedTimeStamp { get; set; }
    public DateTime UpdatedTimeStamp { get; set; }
}