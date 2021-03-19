using Newtonsoft.Json;

namespace Jorgelig.Navent.HttpClients.Inmobiliarias
{
    public class InmobiliariasPagableRequest
    {
        [JsonProperty(PropertyName = "pageable.size")]
        public int Size { get; set; } = 100;
        [JsonProperty(PropertyName = "pageable.page")]
        public int Page { get; set; } = 0;
        [JsonProperty(PropertyName = "access_token")]
        public string? AccessToken { get; set; }
    }
}
