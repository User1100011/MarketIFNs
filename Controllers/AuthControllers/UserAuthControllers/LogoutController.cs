using Market.DbContexts;
using Market.Filters;
using Market.Interfaces;
using Market.Models.Entityes;
using Market.Services.EntityServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [Route("/[action]")]
    public class LogoutController : Controller
    {
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly ILogger<LogoutController> _logger;
        public LogoutController(SignInManager<UserEntity> signInManager,
            ILogger<LogoutController> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Logout() => View("Views/LoginController/Logout.cshtml");

        [HttpPost, ValidationFilter, ValidateAntiForgeryToken, RequireHttps]
        public IActionResult LogoutPost()
        {
            _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
