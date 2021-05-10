using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Jorgelig.HttpClient.ClientHttp;
using Jorgelig.Navent.HttpClients.Inmobiliarias;
using Jorgelig.Navent.Interfaces;
using Jorgelig.Navent.Interfaces.Client;
using Jorgelig.Navent.Utils;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Jorgelig.Navent.HttpClients
{
    /// <summary>
    /// Inmuebles24 integration
    /// Doc: https://open.navent.com/
    /// API Sandbox: http://api-rela.sandbox.open.navent.com/
    /// </summary>
    public partial class NaventClient : BaseLogged, INaventClient
    {
        private static NaventOptions _options;
        private static RestClient _restClient;

        public NaventClient(IOptions<NaventOptions> options, System.Net.Http.HttpClient client) 
        {
            _options = options.Value;
            _restClient = new RestClient(client, _options.ApiBaseUrl);
        }

    }

    public class NaventErrorResult
    {
        public bool? IsSuccessStatusCode { get; set; }
        public int? StatusCode { get; set; }
        public string? Error { get; set; }
        public string? Content { get; set; }
    }

    public class NaventResourcePath
    {
        public const string ApplicationLogin = "/v1/application/login";
        public const string Inmobiliarias = "/v1/inmobiliarias/";
    }

}