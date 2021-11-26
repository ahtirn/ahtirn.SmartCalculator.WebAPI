// using System;
// using System.IO;
// using System.Text;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using ahtirn.Domain.Interfaces;
//
// namespace ahtirn.BusinessLogic.Services
// {
//     public class LoggerUsersService : ILogService
//     {
//         private readonly string _pathLogFile;
//
//         #region ctor
//         public LoggerUsersService()
//         {
//             _pathLogFile = @"C:\Users\User\Desktop\proect\ahtirn.SmartCalculator\ahtirn.SmartCalculator.WebAP\LogFiles\LogUsers\log_file.log";
//         }
//
//         public LoggerUsersService(string path)
//         {
//             _pathLogFile = path;
//         }
//         
//         #endregion
//
//         public async Task LogAsync(HttpRequest request)
//         {
//             try
//             {
//                 if (request != null)
//                 {
//                     await File.AppendAllTextAsync(_pathLogFile, await GetBodyAsync(request));
//                 }
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//             }
//         }
//
//         private async Task<string> GetBodyAsync(HttpRequest request)
//         {
//             string body = string.Empty;
//             
//             if (request.ContentLength > 0 && request.Body.CanRead)
//             {
//                 await using (var outputStream = new MemoryStream())
//                 {
//                     var inputStream = request.Body;
//                     await inputStream.CopyToAsync(outputStream);
//                     outputStream.Position = 0;
//                     
//                     body = await new StreamReader(outputStream, Encoding.UTF8).ReadToEndAsync();
//                 }
//                 // Перемотка назад, чтобы ядро не потерялось при поиске тела запроса
//                 request.Body.Position = 0;
//             }
//
//             return body;
//         }
//     }
// }