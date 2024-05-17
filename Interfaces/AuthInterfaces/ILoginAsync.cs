using Market.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using CSharpFunctionalExtensions;

namespace Market.Interfaces.AuthInterfaces
{
    public interface ILoginAsync
    {
        public Task<Result<IActionResult>> LoginAsync(LoginModel model);

    }
}