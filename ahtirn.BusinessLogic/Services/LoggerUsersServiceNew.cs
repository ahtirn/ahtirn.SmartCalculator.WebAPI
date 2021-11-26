using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ahtirn.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ahtirn.BusinessLogic.Services
{
    public class LoggerUsersServiceNew : ILogService
    {
        private readonly string _pathLogFile;
        
        public LoggerUsersServiceNew()
        {
            // _request = request;
            _pathLogFile = @"C:\Users\User\Desktop\proect\ahtirn.SmartCalculator\ahtirn.SmartCalculator.WebAP\LogFiles\LogUsers\log_file.log";
        }

        public async Task LogAsync(HttpRequest _request)
        {
            try
            {
                if (_request != null)
                {
                    await File.AppendAllTextAsync(_pathLogFile, await LogEditBody(_request));
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.StatusCode);
            }
        }

        private async Task<string> LogEditBody(HttpRequest _request)
        {
            var body = await GetBodyAsync(_request);
            if (!string.IsNullOrWhiteSpace(body))
            {
                var info = $"{DateTime.Now.ToLongTimeString()} " +
                           $"\n{_request.HttpContext.Request.Path} " +
                           $"\n{_request.HttpContext.Request.Host}";
                           
                return info + body;
            }
            return body;
        }
        
        private async Task<string> GetBodyAsync(HttpRequest _request)
        {
            string body = string.Empty;
             
            if (_request.ContentLength > 0 && _request.Body.CanRead)
            {
                // Enables reading the request body multiple times.  
                _request.EnableBuffering();
                
                await using (var outputStream = new MemoryStream())
                {
                    var inputStream = _request.Body;
                    await inputStream.CopyToAsync(outputStream);
                    outputStream.Position = 0;
                     
                    body = await new StreamReader(outputStream, Encoding.UTF8)
                        .ReadToEndAsync();
                }
                // Перемотка назад, чтобы ядро не потерялось при поиске тела запроса
                _request.Body.Position = 0;
            }

            return body;
        }
    }
}