// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Builder;
// using ahtirn.Domain.Interfaces;
//
// namespace ahtirn.SmartCalculator.API
// {
//     internal class LoggerUsersMiddleware
//     {
//         private readonly RequestDelegate _next;
//         private readonly ILogService _logService;
//
//         public LoggerUsersMiddleware(RequestDelegate next, ILogService logService)
//         {
//             _next = next;
//             _logService = logService;
//         }
//
//         public async Task Invoke(HttpContext context)
//         {
//             await _logService.LogAsync(context.Request);
//             await _next.Invoke(context);
//         }
//     }
//
//     public static class LoggerExtension
//     {
//         public static IApplicationBuilder UseLoggerMiddleware(this IApplicationBuilder builder)
//         {
//             return builder.UseMiddleware<LoggerUsersMiddleware>();
//         }
//     }
// }