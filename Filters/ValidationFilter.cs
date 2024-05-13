using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Market.Filters
{
    public class ValidationFilter : IActionFilter
    {
        private readonly ILogger<ValidationFilter> _logger;
        public ValidationFilter(ILogger<ValidationFilter> logger)
        {
            _logger = logger;
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.ModelState.IsValid is false)
            {
                context.Result = new BadRequestResult();
                context.Canceled = true;
                _logger.LogWarning("{x} no valid", context.ModelState);

                return;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
