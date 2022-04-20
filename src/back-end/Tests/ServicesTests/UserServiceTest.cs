using System;
using System.Threading.Tasks;
using Application.Dto;
using Application.MapperProfiles;
using Application.Services.Implementations;
using AutoMapper;
using Domain;
using Domain.Entities;
using Moq;
using Xunit;

namespace Tests.ServicesTests;

public class UserServiceTest
{
    private readonly UserService _userService;
    private readonly Mock<IRepository<User>> _userRepoMock = new Mock<IRepository<User>>();
    private const string ExistingUserId = "existing-user-id";
    
    private readonly IMapper _mapper = new Mapper(
        new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<DeviceProfile>();
            cfg.AddProfile<OSProfile>();
            cfg.AddProfile<ProjectMembershipProfile>();
            cfg.AddProfile<ProjectProfile>();
            cfg.AddProfile<UserProfile>(); 
        }));

    public UserServiceTest()
    {
        _userService = new UserService(_userRepoMock.Object, _mapper);
    }
    
    [Fact]
    public async Task GetByIdAsync_ShouldReturnUser_WhenUserExists()
    {
        // Arrange
        var userToReturn = new User()
        {
            Id = ExistingUserId,
            UserName = "Rick Sanchez",
            Email = "ricks@gmail.com"
        };
        _userRepoMock.Setup(x => x.FindByIdAsync(ExistingUserId))
            .ReturnsAsync(userToReturn);
        
        // Act
        var user = await _userService.GetUserByIdAsync(ExistingUserId);
        
        // Assert
        Assert.Equal(ExistingUserId, user.Id);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNull_WhenUserDoesNotExist()
    {
        // Arrange
        var existingUser = new User()
        {
            Id = ExistingUserId,
            UserName = "Rick Sanchez",
            Email = "ricks@gmail.com"
        };
        var nonExistingUserId = Guid.NewGuid().ToString();
        
        _userRepoMock.Setup(x => x.FindByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(() => null);
        
        // Act
        var user = await _userService.GetUserByIdAsync(nonExistingUserId);
        
        // Assert
        Assert.Null(user);
    }

    [Fact]
    public async Task AddUserAsync_ShouldReturnAddedUser_WhenUserDoesNotExists()
    {
        // Arrange
        _userRepoMock.Setup(repo => repo.Add())
        // Act
        
        // Assert
    }
    
    [Fact]
    public async Task AddUserAsync_ShouldThrowRecordAlreadyExistsException_WhenUserExists(){}

    [Theory]
    [InlineData(ExistingUserId, true)]
    [InlineData("non-existing-id", false)]
    public async Task UserExists_CheckExistence_Theory(string userId, bool expected)
    {
        // Arrange
        _userRepoMock.Setup(x => x.Exists(ExistingUserId))
            .ReturnsAsync(true);
        // Act
        var result = await _userService.UserExistsAsync(userId);
        // Assert
        Assert.Equal(result, expected);
    }
    
}