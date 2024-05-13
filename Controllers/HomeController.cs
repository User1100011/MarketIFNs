using Market.Filters;
using Market.Models;
using Market.Models.Entityes;
using Market.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Market.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpGet("")]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("/Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("/Account")]
        [Authorize, ValidationFilter, RequireHttps]
        public async Task<IActionResult> Account([FromServices] UserManager<UserEntity> userManager)
        {
            var user = await userManager.GetUserAsync(User);

            return View(new UserViewModel { Email = user.Email,
                UserName = user.UserName, ProfilePicturePath = user.ProfilePicturePath });
        }
    }
}
