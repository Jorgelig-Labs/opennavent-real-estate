using System.Threading.Tasks;
using Jorgelig.Navent.HttpClients.Application;

namespace Jorgelig.Navent.Interfaces
{
    public interface INaventService
    {
        public Task<ApplicationLoginResponse?>? Login(string clientId, string clientSecret, string? grantType = null);
    }
}