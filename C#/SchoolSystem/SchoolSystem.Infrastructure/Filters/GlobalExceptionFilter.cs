using Microsoft.AspNetCore.Mvc.Filters;

namespace SchoolSystem.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}