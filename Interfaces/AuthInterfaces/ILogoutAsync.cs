using Microsoft.AspNetCore.Mvc;
using CSharpFunctionalExtensions;

namespace Market.Interfaces.AuthInterfaces
{
    public interface ILogoutAsync
    {
        public Task<Result<IActionResult>> Logout(Guid userId);

    }
}