using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto dto);
    Task UpdateAsync(PostUpdateDto post);
    Task DeleteAsync(int id);
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters);
    Task<PostBasicDto> GetByIdAsync(int id);
}