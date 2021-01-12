using Newtonsoft.Json;
using System.Collections.Generic;

namespace JunoApiIntegration.Responses
{
    public class ChargeListResponse
    {
        [JsonProperty("_embedded")]
        public Embedded Embedded { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }
}
