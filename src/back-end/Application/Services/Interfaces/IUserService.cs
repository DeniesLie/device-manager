using Domain.Entities;
using Infrastructure;
using Application.Dto;

namespace Application.Services.Interfaces;

public interface IUserService
{
    Task<UserDto?> GetUserById(string userId);
    Task<UserDto> AddUserAsync(UserDto userDto);
    Task<bool> UserExistsAsync(string userId);
}