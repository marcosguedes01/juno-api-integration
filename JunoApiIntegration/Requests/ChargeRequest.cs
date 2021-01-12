using Newtonsoft.Json;
using System.Collections.Generic;

namespace JunoApiIntegration.Requests
{
    public class ChargeRequest
    {
        [JsonProperty("charge")]
        public Charge Charge { get; set; }

        [JsonProperty("billing")]
        public Billing Billing { get; set; }
    }

    public class Charge
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("references")]
        public List<string> References { get; set; }

        /// <summary>
        /// Valor do boleto para cobrança
        /// </summary>
        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        /// Valor da multa
        /// </summary>
        [JsonProperty("fine")]
        public int Fine { get; set; }

        /// <summary>
        /// Valor do Juros de Mora
        /// </summary>
        [JsonProperty("interest")]
        public string Interest { get; set; }

        /// <summary>
        /// Data de Vencimento no formato "yyyy-MM-dd"
        /// </summary>
        [JsonProperty("dueDate")]
        public string DueDate { get; set; }

        /// <summary>
        /// Máximo de dias vencidos
        /// </summary>
        [JsonProperty("maxOverdueDays")]
        public int MaxOverdueDays { get; set; }

        /// <summary>
        /// Permitir adiantamento de pagamento
        /// </summary>
        /// <remarks>
        /// Antecipações consistem no recebimento adiantado de uma transação, seja ela parcelada ou não.
        /// Disponível apenas para cartão de crédito, com a Juno você pode decidir se deseja ou não fazer esse 
        /// adiantamento de maneira flexível via API com o paymentAdvance. O serviço inclui taxas.
        /// </remarks>
        /// <see cref="https://junocx.zendesk.com/hc/pt-br/articles/360041256631-Posso-pedir-antecipa%C3%A7%C3%A3o-do-pagamento-para-cobran%C3%A7as-parceladas-"/>
        [JsonProperty("paymentAdvance")]
        public bool PaymentAdvance { get; set; }
    }

    public class Billing
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("document")]
        public string Document { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Data de nascimento no formato "yyyy-MM-dd"
        /// </summary>
        [JsonProperty("birthDate")]
        public string BirthDate { get; set; }

        [JsonProperty("notify")]
        public bool Notify { get; set; }
    }
}
