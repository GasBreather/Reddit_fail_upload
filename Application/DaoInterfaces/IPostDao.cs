using Domain.DTOs;
using Domain.Models;

namespace Application.DaoInterfaces;

public interface IPostDao
{
   Task<Post> CreateAsync(Post post);
   Task UpdateAsync(Post post);
   Task<Post> GetByIdAsync(int id);
   Task DeleteAsync(int id);
   Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters);
}