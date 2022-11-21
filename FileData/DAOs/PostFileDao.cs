using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }
    public Task<Post> CreateAsync(Post post)
    {
        int id = 1;
        if (context.Posts.Any())
        {
            id = context.Posts.Max(t => t.ID);
            id++;
        }
        post.ID = id;
        context.Posts.Add(post);
        context.SaveChanges();
        return Task.FromResult(post);
    }

    public Task UpdateAsync(Post postToUpdate)
    {
        Post? existing = context.Posts.FirstOrDefault(post => post.ID == postToUpdate.ID);
        if (existing == null)
        {
            throw new Exception($"Post with id {postToUpdate.ID} does not exist!");
        }

        context.Posts.Remove(existing);
        context.Posts.Add(postToUpdate);
    
        context.SaveChanges();
    
        return Task.CompletedTask;

    }
    
    public Task DeleteAsync(int id)
    {
        Post? existing = context.Posts.FirstOrDefault(post => post.ID == id);
        if (existing == null)
        {
            throw new Exception($"Post with id {id} does not exist!");
        }

        context.Posts.Remove(existing); 
        context.SaveChanges();
    
        return Task.CompletedTask;
    }

    public Task<Post> GetByIdAsync(int postId)
    {
        Post? existing = context.Posts.FirstOrDefault(t => t.ID == postId);
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        IEnumerable<Post> result = context.Posts.AsEnumerable();
        if (!string.IsNullOrEmpty(searchParameters.Username))
        {
            // we know username is unique, so just fetch the first
            result = context.Posts.Where(post =>
                post.OP.UserName.Equals(searchParameters.Username, StringComparison.OrdinalIgnoreCase));
        }

        if (searchParameters.UserId != null)
        {
            result = result.Where(t => t.OP.Id == searchParameters.UserId);
        }
        

        if (!string.IsNullOrEmpty(searchParameters.TitleContains))
        {
            result = result.Where(t =>
                t.Title.Contains(searchParameters.TitleContains, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(result);
    }
}