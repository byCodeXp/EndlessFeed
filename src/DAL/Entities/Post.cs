using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Post : Entity
    {
        public string Text { get; set; }
        public User Author { get; set; }
        public Publish Publish { get; set; }
    }
}