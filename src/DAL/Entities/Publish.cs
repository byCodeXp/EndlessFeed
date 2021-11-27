using System;
using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Publish : Entity
    {
        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}