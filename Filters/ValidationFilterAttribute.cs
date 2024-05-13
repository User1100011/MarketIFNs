using Microsoft.AspNetCore.Mvc;

namespace Market.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ValidationFilterAttribute : ServiceFilterAttribute<ValidationFilter>
    {

    }
}
