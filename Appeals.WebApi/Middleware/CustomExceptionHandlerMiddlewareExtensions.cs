using Microsoft.AspNetCore.Builder;

namespace Appeals.WebApi.Middleware
{
    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
            return builder;
        }
    }
}
