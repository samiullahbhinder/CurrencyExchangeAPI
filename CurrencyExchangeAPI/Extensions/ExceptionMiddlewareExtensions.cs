using CurrencyExchangeAPI.Middlewares;

namespace CurrencyExchangeAPI.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        
        public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
