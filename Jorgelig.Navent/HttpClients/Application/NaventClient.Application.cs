using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;
using Jorgelig.Navent.Extensions;
using Jorgelig.Navent.HttpClients;
using Jorgelig.Navent.HttpClients.Application;
using Jorgelig.Navent.Interfaces;
using Jorgelig.Navent.Interfaces.Client;
using Jorgelig.Navent.Utils;
using Serilog.Events;


// ReSharper disable once CheckNamespace
namespace Jorgelig.Navent.HttpClients
{
    /// <summary>
    /// https://open.navent.com/api-reference/intro
    /// </summary>
    public partial class NaventClient : BaseLogged,INaventClient
    {
        public async Task<ApplicationLoginResponse?> Login(string clientId, string clientSecret, string grantType = "client_credentials")
        {
            _log.Enter(LogEventLevel.Debug, arguments: new object?[] {clientId, clientSecret, grantType});
            var loginUrl =
                $"{NaventResourcePath.ApplicationLogin}?grant_type={grantType}&client_id={clientId}&client_secret={clientSecret}";
            try
            {
                var result = await _restClient.ExecuteApi<ApplicationLoginResponse>(HttpMethod.Post, loginUrl);
                
                return result;
            }
            catch (Exception e)
            {
                _log.Exception(LogEventLevel.Error, arguments: new object?[] {clientId, clientSecret, grantType});
            }

            return default;
        }
        
        public Task<string> Logout(string clientId, string clientSecret, string token)
        {
            throw new NotImplementedException();
        }
    }
}