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
    private readonly ILogger<UserService> _logger;
    
    public UserService(IRepository<User> userRepo, IMapper mapper, ILogger<UserService> logger)
    {
        _userRepo = userRepo;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<UserDto?> GetUserById(string userId)
        => _mapper.Map<UserDto?>(await _userRepo.FindByIdAsync(userId));

    public async Task<UserDto> AddUserAsync(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        _userRepo.Add(user);
        await _userRepo.SaveChangesAsync();
        _logger.LogInformation("User {0} has joined the service", user.UserName);
        return _mapper.Map<UserDto>(user);
    }

}