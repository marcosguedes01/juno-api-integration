using Newtonsoft.Json;

namespace JunoApiIntegration.Responses
{
    public class BillingBillResponse
    {
        [JsonProperty("_embedded")]
        public Embedded Embedded { get; set; }
    }
}
