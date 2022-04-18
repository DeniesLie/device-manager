using Application.Dto;
using Application.Services.Interfaces;
using AutoMapper;
using Domain;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Services.Implementations;

public class UserService : IUserService
{
    private readonly IRepository<User> _userRepo;
    private readonly IMapper _mapper;
    
    public UserService(IRepository<User> userRepo, IMapper mapper, ILogger<UserService> logger)
    {
        _userRepo = userRepo;
        _mapper = mapper;
    }

    public async Task<UserDto?> GetUserById(string userId)
        => _mapper.Map<UserDto?>(await _userRepo.FindByIdAsync(userId));

    public async Task<UserDto> AddUserAsync(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        _userRepo.Add(user);
        await _userRepo.SaveChangesAsync();
        return _mapper.Map<UserDto>(user);
    }
    
    public async Task<bool> UserExistsAsync(string userId)
        => await _userRepo.Exists(userId);
}