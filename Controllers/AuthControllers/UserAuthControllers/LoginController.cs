using Market.DbContexts;
using Market.Filters;
using Market.Interfaces;
using Market.Models.Entityes;
using Market.Models.ViewModels;
using Market.OtherScripts;
using Market.Services.EntityServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IPasswordHasher = Market.Interfaces.HashingInterfaces.IPasswordHasher;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Market.Controllers
{
    [Route("/[action]")]
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View("Views/LoginController/Login.cshtml");
        }

        [HttpPost, ValidationFilter, ValidateAntiForgeryToken, RequireHttps]
        public async Task<IActionResult> LoginPostAsync([FromForm] LoginModel model)
        {
            return RedirectToAction("Account", "Home");
        }
    }
}
