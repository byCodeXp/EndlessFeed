using DAL.Entities.Base;

namespace DAL.Entities;

public class Comment : Entity
{
    public string Text { get; set; }
    public Post Post { get; set; }
    public User Author { get; set; }
    public BlockComment BlockComment { get; set; }
}