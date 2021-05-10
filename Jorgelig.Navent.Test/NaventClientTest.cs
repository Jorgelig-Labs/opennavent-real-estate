using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Jorgelig.Navent.HttpClients;
using Jorgelig.Navent.HttpClients.Inmobiliarias;
using Jorgelig.Navent.Interfaces.Client;
using Jorgelig.Navent.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Xunit;

namespace Jorgelig.Navent.Test
{
    public class NaventClientTest
    {
        private readonly INaventClient _client;
        public static IConfigurationRoot Configuration { get; set; }
        /// <summary>
        /// https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.1&tabs=windows
        /// </summary>
        private string? ClientId => Configuration["AppSettings:NaventAccount:ClientId"] ?? String.Empty;
        private string? ClientSecret => Configuration["AppSettings:NaventAccount:ClientSecret"] ?? String.Empty;

        public NaventClientTest()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddUserSecrets<NaventClientTest>();
            Configuration = builder.Build();

            var options = Options.Create(new NaventOptions()
            {
                ApiBaseUrl = "http://api-rela.sandbox.open.navent.com/"
                //ApiBaseUrl = "https://webhook.site/14f755c6-b8e4-4bdd-8cf7-74ad58b3ab29"
                //ApiBaseUrl = "https://enaolv4fea1wq4s.m.pipedream.net"
            });

            //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback += 
                (sender, certificate, chain, errors) =>
                {
                    return true;
                };


            _client = new NaventClient(options, new System.Net.Http.HttpClient(handler));
        }

        [Fact]
        public async Task ApplicationLogin_ResultToken()
        {
            var token = await _client.Login(ClientId, ClientSecret);

            Assert.NotNull(token);
            Assert.NotNull(token?.AccessToken);
            
        }

        [Fact]
        public async Task Inmobiliarias_ResultList()
        {
            var loginResponse = await _client.Login(ClientId, ClientSecret);
            
            InmobiliariasPagableRequest? request = new InmobiliariasPagableRequest
            {
                AccessToken = loginResponse?.AccessToken,
                Page = 1,
                Size = 10
            };
            var list = await _client.Search(request);
            
            Assert.NotNull(list);
            Assert.True(list?.Number > 0);
        }
    }
}
