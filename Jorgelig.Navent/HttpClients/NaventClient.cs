using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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
        private static HttpClient _client;
        private static NaventOptions _options;

        public NaventClient(IOptions<NaventOptions> options, HttpClient client) 
        {
            _client = client;
            _options = options.Value;
        }

        private async Task<TResult?> ExecuteApi<TResult>(HttpMethod method, string resourcePath,
            AuthenticationHeaderValue? authenticationHeader = null,
            object? data = null) where TResult : class
        {
            var url = GetUrl(resourcePath);
            var httpRequestMessage = new HttpRequestMessage(method, url);

            try
            {
                httpRequestMessage = AddStringContent(httpRequestMessage, data);
                httpRequestMessage = AddAuthenticationHeader(httpRequestMessage, authenticationHeader);

                var httpResponse = await _client.SendAsync(httpRequestMessage);
                var resultContent = await httpResponse.Content.ReadAsStringAsync();

                if (httpResponse.IsSuccessStatusCode)
                {
                    if (string.IsNullOrWhiteSpace(resultContent)) return new NaventErrorResult{IsSuccessStatusCode = false} as TResult;

                    var result =
                        JsonConvert.DeserializeObject<TResult?>(resultContent, JsonUtils.StringEnumJsonSerializerSettings);

                    return result;
                }

                var error = new NaventErrorResult
                {
                    IsSuccessStatusCode = false,
                    Content = resultContent
                };

                return error as TResult;
            }
            catch (Exception e)
            {
                _log.Error(exception: e, $"[{method}] {resourcePath}");

                return new NaventErrorResult
                {
                    IsSuccessStatusCode = false,
                    Content = e.InnerException?.Message ?? e.Message
                } as TResult;
            }


            return default;
        }

        private string? GetUrl(string? resourcePath)
        {
            var urlBuilder = new UriBuilder(_options.ApiBaseUrl)
            {
                Path = resourcePath
            };
            var url = urlBuilder.Uri.ToString();

            return url;
        }

        private HttpRequestMessage? AddStringContent(HttpRequestMessage? requestMessage, object? data)
        {
            if (requestMessage != null && data != null)
            {
                var json = JsonConvert.SerializeObject(data, JsonUtils.StringEnumJsonSerializerSettings);
                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            return requestMessage;
        }

        private HttpRequestMessage? AddAuthenticationHeader(HttpRequestMessage? requestMessage,
            AuthenticationHeaderValue? authenticationHeader)
        {
            if (authenticationHeader != null)
                requestMessage.Headers.Authorization = authenticationHeader;

            return requestMessage;
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
        public string Inmobiliarias = "/v1/inmobiliarias/";
    }

}