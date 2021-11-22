using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ahtirn.Application.Services
{
    public interface ILogService
    {
        Task LogAsync(HttpRequest request);
    }
}