using Market.DbContexts;
using Market.Filters;
using Market.Interfaces;
using Market.Models.Entityes;
using Market.Models.ViewModels;
using Market.OtherScripts;
using Market.Services.EntityServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IPasswordHasher = Market.Interfaces.IPasswordHasher;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Market.Controllers
{
    [Route("/[action]")]//Было до этого "/[controller]/[action]" я не понимал почему при вводе url "https://localhost:port/LoginController/Login" был 404 код,
                        //я забыл короче что "Controller" в "LoginController" пистаь не нужно, на это я потратил полтора часа где то.
                        //В представлениях тоже самое
    public class LoginController : Controller
    {
        #region AddService
        private readonly ApplicationDbContext _db;
        private readonly UserService _userService;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly UserManager<UserEntity> _userManager;
        private readonly ILogger<LoginController> _logger;
        private readonly IPasswordHasher _passwordHasher;
        public LoginController(ApplicationDbContext dbContext, UserService userService,
           SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager,
           ILogger<LoginController> logger, IPasswordHasher passwordHasher)
        {
            _db = dbContext;
            _userService = userService;
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _passwordHasher = passwordHasher;
        }
        #endregion


        [HttpGet]
        public IActionResult Login()
        {
            return View("Views/LoginController/Login.cshtml");
        }

        [HttpPost, ValidationFilter, ValidateAntiForgeryToken, RequireHttps]
        public async Task<IActionResult> LoginPostAsync([FromForm] LoginModel model)
        {
            if (_userManager.FindByEmailAsync(model.Email) is null)
                return NotFound($"User with email {model.Email} not found");

            var user = new UserEntity
            {
                Email = model.Email,
                PasswordHash = _passwordHasher.Hashing(model.Password)
            };
            SignInResult result =
                await _signInManager.PasswordSignInAsync(user, model.Password, model.Remember, false);

            if (result.Succeeded is false)
            {
                _logger.LogWarning("The user was unable to log in to the account," +
                    "possible reasons: IsNotAllowed({x}) or IsLockedOut({y})",
                    result.IsNotAllowed, result.IsLockedOut);

                return Forbid();
            }

            _logger.LogInformation("The user with email {x} logged into the account", model.Email);
            return RedirectToAction("Account", "Home");
        }
    }
}
