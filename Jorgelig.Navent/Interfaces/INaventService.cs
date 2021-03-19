using System.Threading.Tasks;

namespace Jorgelig.Navent.Interfaces
{
    public interface INaventService
    {
        public Task<string?>? Login(string clientId, string clientSecret, string? grantType = null);
    }
}