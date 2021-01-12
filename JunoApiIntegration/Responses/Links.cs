using Newtonsoft.Json;

namespace JunoApiIntegration.Responses
{
    public class Links
    {
        [JsonProperty("self")]
        public Self Self { get; set; }
    }
}
