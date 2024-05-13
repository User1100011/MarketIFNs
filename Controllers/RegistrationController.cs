using Market.DbContexts;
using Market.Filters;
using Market.Interfaces;
using Market.Models.Entityes;
using Market.Models.ViewModels;
using Market.OtherScripts.Enums;
using Market.Services.EntityServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [Route("/[action]")]
    public class RegistrationController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserService _userService;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly UserManager<UserEntity> _userManager;
        private readonly ILogger<RegistrationController> _logger;
        private readonly IPasswordHasher _passwordHasher;
        public RegistrationController(ApplicationDbContext dbContext, UserService userService,
           SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager,
           ILogger<RegistrationController> logger, IPasswordHasher passwordHasher)
        {
            _db = dbContext;
            _userService = userService;
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _passwordHasher = passwordHasher;
        }


        [HttpGet]
        public IActionResult Registration()
        {
            return View("Views/LoginController/Registration.cshtml");
        }

        [HttpPost, ValidationFilter, ValidateAntiForgeryToken, RequireHttps]
        public async Task<IActionResult> RegistrationPostAsync([FromForm] RegistrationModel model,
            [FromServices] IEmailSender emailSender,
            [FromServices] IIdentityResultCheck identityResultCheck)
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                return Conflict($"The user with mail {model.Email} already exists");

            var newUser = new UserEntity
            {
                UserName = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                PasswordHash = _passwordHasher.Hashing(model.Password)
            };
            await emailSender.SendEmailAsync(newUser.Email, "confimation", "Email confirmation");

            identityResultCheck.Check(
                await _userManager.CreateAsync(newUser));


            var createdUser = await _userManager.FindByEmailAsync(newUser.Email);
            identityResultCheck.Check(
                await _userManager.AddToRolesAsync(
                    createdUser, new List<string> { Roles.User.ToString() }));


            await _signInManager.SignInAsync(newUser, model.Remember);

            return RedirectToAction("Account", "Home");
        }
    }
}
