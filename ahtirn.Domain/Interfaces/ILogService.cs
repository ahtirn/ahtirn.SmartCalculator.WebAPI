using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ahtirn.Domain.Interfaces
{
    public interface ILogService
    {
        Task LogAsync(HttpRequest request);
    }
}