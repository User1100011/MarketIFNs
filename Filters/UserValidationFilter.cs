using FluentValidation;
using Market.Models.Entityes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;

namespace Market.Filters
{
    public class UserValidationFilter : IActionFilter
    {
        private readonly ILogger<UserValidationFilter> _logger;
        private readonly IValidator<UserEntity> _validator;
        private readonly UserManager<UserEntity> _userManager;
        public UserValidationFilter(ILogger<UserValidationFilter> logger,
            IValidator<UserEntity> validator, UserManager<UserEntity> userManager)
        {
            _logger = logger;
            _validator = validator;
            _userManager = userManager;
        }
        public async void OnActionExecuted(ActionExecutedContext context)
        {
            var user = await _userManager.GetUserAsync(context.HttpContext.User);

            if (user == null)
            {
                context.Result = new UnauthorizedResult();
                context.Canceled = true;

                _logger.LogWarning("User is null");
                return;
            }

            var result = await _validator.ValidateAsync(user);
            
            if (result.IsValid is false)
            {
                context.Result = new BadRequestResult();
                context.Canceled = true;

                foreach (var item in result.Errors)
                    _logger.LogWarning("Not valid: {x}", item.ErrorMessage);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
