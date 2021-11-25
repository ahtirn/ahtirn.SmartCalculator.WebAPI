using System;
using System.IO;
using System.Threading.Tasks;
using ahtirn.Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ahtirn.BusinessLogic.Services
{
    public class LoggerUsersServiceNew : ILogService
    {
        private readonly string _pathLogFile;
        public LoggerUsersServiceNew()
        {
            _pathLogFile = @"C:\Users\User\Desktop\proect\ahtirn.SmartCalculator\ahtirn.SmartCalculator.WebAP\LogFiles\LogUsers\log_file.log";
        }
        public Task LogAsync(HttpRequest request)
        {
            try
            {
                if (request != null)
                {
                    await File.AppendAllTextAsync(_pathLogFile, await );
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}