using System.Threading.Tasks;
using Jorgelig.Navent.HttpClients;
using Jorgelig.Navent.Interfaces;

namespace Jorgelig.Navent
{

    public class NaventService : INaventService
    {

        private static NaventClient _client;

        public NaventService(NaventClient client)
        {
            _client = client;
        }

        public async Task<string?>? Login(string? clientId, string? clientSecret, string? grantType)
        {
            var result = await _client.Login(clientId, clientSecret, grantType);
            
            return result;
        }
    }
}
