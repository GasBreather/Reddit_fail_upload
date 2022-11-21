using System.Text.Json;
using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<User> CreateAsync(UserCreationDto dto);

    Task<IEnumerable<User>> GetUsers(string? usernameContains = null);
}