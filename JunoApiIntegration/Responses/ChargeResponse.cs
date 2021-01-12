using Newtonsoft.Json;

namespace JunoApiIntegration.Responses
{
    public class ChargeResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("dueDate")]
        public string DueDate { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("checkoutUrl")]
        public string CheckoutUrl { get; set; }

        [JsonProperty("installmentLink")]
        public string InstallmentLink { get; set; }

        [JsonProperty("payNumber")]
        public string PayNumber { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        /// ACTIVE, CANCELLED
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("billetDetails")]
        public BilletDetails BilletDetails { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }
}
