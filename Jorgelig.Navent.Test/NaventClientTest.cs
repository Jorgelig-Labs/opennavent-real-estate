using System;
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
            });
            _client = new NaventClient(options, new HttpClient());
        }

        [Fact]
        public async Task ApplicationLogin_ResultToken()
        {
            var token = await _client.Login(ClientId, ClientSecret);

            Assert.NotNull(token);
            Assert.True(!string.IsNullOrWhiteSpace(token));
        }

        [Fact]
        public async Task Inmobiliarias_ResultList()
        {
            var token = await _client.Login(ClientId, ClientSecret);
            InmobiliariasPagableRequest? request = null;
            var list = await _client.Search(token, request);
            
            Assert.NotNull(list);
            Assert.NotEmpty(list?.Content);
        }
    }
}
