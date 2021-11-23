using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ahtirn.Domain.Interfaces;
using Microsoft.AspNetCore.Builder;

//Временно без DI
using ahtirn.BusinessLogic.Services;

namespace ahtirn.SmartCalculator.API
{
    class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogService _logService;

        public LoggerMiddleware(RequestDelegate next)
        {
            _next = next;
            //TODO: Временно без DI
            _logService = new LoggerService();
        }

        public async Task Invoke(HttpContext context)
        {
            await _logService.LogAsync(context.Request);
            await _next.Invoke(context);
        }
    }

    public static class LoggerExtension
    {
        public static IApplicationBuilder UseLoggerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggerMiddleware>();
        }
    }
}