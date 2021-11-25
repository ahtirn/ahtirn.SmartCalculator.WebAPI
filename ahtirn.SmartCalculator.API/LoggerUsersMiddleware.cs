using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

//Временно без DI
using ahtirn.BusinessLogic.Services;
using ahtirn.Core.Interfaces;

namespace ahtirn.SmartCalculator.API
{
    class LoggerUsersMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogService _logService;

        public LoggerUsersMiddleware(RequestDelegate next)
        {
            _next = next;
            //TODO: Временно без DI
            _logService = new LoggerUsersService();
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
            return builder.UseMiddleware<LoggerUsersMiddleware>();
        }
    }
}