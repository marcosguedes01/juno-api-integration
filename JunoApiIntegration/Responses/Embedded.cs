using Newtonsoft.Json;
using System.Collections.Generic;

namespace JunoApiIntegration.Responses
{
    public class Embedded
    {
        [JsonProperty("charges")]
        public List<ChargeResponse> Charges { get; set; }
    }
}
