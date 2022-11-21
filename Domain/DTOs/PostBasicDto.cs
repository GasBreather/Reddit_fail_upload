namespace Domain.DTOs;

public class PostBasicDto
{
    public int Id { get; }
    public string OpUsername { get; }
    public string Title { get; }
    public string Body { get; }
    

    public PostBasicDto(int id, string opUsername, string title, string body)
    {
        Id = id;
        OpUsername = opUsername;
        Title = title;
        Body = body;
    }
}