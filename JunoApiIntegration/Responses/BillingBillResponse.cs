using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace JunoApiIntegration.Responses
{
    public class BillingBillResponse : IBillingBillResponse
    {
        // Success
        [JsonProperty("_embedded")]
        public Embedded Embedded { get; set; }

        // Error
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("details")]
        public List<Detail> Details { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
    }
}
