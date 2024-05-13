using Microsoft.AspNetCore.Identity;
using Market.Interfaces;

namespace Market.Services
{
    public class IdentityService : IIdentityResultCheck
    {
        private ILogger<IdentityService> _logger;
        public IdentityService(ILogger<IdentityService> logger)
        {
            _logger = logger;
        }

        public bool Check(IdentityResult identityResult)
        {
            var result = false;

            if (identityResult.Succeeded is false)
                foreach (var error in identityResult.Errors)
                {
                    _logger.LogWarning("Description: {d}, code: {c}", 
                        error.Description, error.Code);

                    result = true;
                }

            _logger.LogInformation("{Succeeded}", identityResult.Succeeded);
            return result;
        }
    }
}
