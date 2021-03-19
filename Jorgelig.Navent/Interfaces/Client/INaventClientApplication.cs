using System.Threading.Tasks;

namespace Jorgelig.Navent.Interfaces.Client
{
    public interface INaventClientApplication
    {
        /// <summary>
        /// Autentificación de aplicaciones mediante el protocolo de OAuth2
        /// </summary>
        /// <param name="clientId">User</param>
        /// <param name="clientSecret">Password</param>
        /// <param name="grantType">Default value: client_credentials</param>
        /// <returns></returns>
        /// <see cref="https://open.navent.com/api-reference/api_endpoints/authentication-application/loginusingpost"/>
        Task<string> Login(string clientId, string clientSecret, string grantType = "client_credentials");

        /// <summary>
        /// Revoca el token del protocolo de OAuth2
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <see cref="https://open.navent.com/api-reference/api_endpoints/authentication-application/revokeaccesstokenusingpost"/>
        Task<string> Logout(string clientId, string clientSecret, string token);
    }
}