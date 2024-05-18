using Market.DbContexts;
using Market.Services.EntityServices;
using Market.Models.Entityes;
using Market.Interfaces.HashingInterfaces;

namespace Market.Services.AuthServices
{
    public class SalesmanAuthService
    {
        private readonly UserService _userService;
        private readonly ILogger<UserAuthService> _logger;
        private readonly IPasswordHasher _passwordHasher;
        public SalesmanAuthService(UserService userService,
           ILogger<UserAuthService> logger, IPasswordHasher passwordHasher)
        {
            _userService = userService;
            _logger = logger;
            _passwordHasher = passwordHasher;
        
        
        }

         
    }
}