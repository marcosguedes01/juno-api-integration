using Newtonsoft.Json;

namespace JunoApiIntegration.Responses
{
    public class Self
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
