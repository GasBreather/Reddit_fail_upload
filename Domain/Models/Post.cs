using System.Reflection.Metadata;

namespace Shared.Models;

public class Post
{
    public int ID { get; set; }
    public User OP { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public Post(User OP, string Title, string Body)
    {
        this.OP = OP;
        this.Title = Title;
        this.Body = Body;
    }
}