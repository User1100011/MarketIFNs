using Market.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using CSharpFunctionalExtensions;

namespace Market.Interfaces.AuthInterfaces
{
    public interface IRegistrationAsync
    {
        public Task<Result<IActionResult>> RegistrationPostAsync(RegistrationModel model);
    }

}