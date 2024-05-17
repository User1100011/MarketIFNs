using Market.DbContexts;
using Market.Services.EntityServices;
using Market.Models.Entityes;
using Market.Interfaces.HashingInterfaces;
using Market.Interfaces.AuthInterfaces;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Market.Models.ViewModels;

namespace Market.Services.AuthServices
{
    public class UserAuthService : ILoginAsync, IRegistrationAsync, ILogoutAsync
    {
        private readonly UserService _userService;
        private readonly ILogger<UserAuthService> _logger;
        private readonly IPasswordHasher _passwordHasher;
        public UserAuthService(UserService userService,
           ILogger<UserAuthService> logger, IPasswordHasher passwordHasher)
        {
            _userService = userService;
            _logger = logger;
            _passwordHasher = passwordHasher;
        
        
        }

        public Task<Result<IActionResult>> LoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }
        public Task<Result<IActionResult>> Logout(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IActionResult>> RegistrationPostAsync(RegistrationModel model)
        {
            throw new NotImplementedException();
        }
    }
}