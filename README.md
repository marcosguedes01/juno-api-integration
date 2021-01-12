# juno-api-integration
Api para integração com o Juno

Permite integração com a plataforma Juno para geração de boletos e consulta de cobranças.

- [Site oficial do Juno](https://juno.com.br/)
- [Documentação complementa do Juno](https://dev.juno.com.br/api/v2)

## Pré-requisitos
Será necessário obter os valores para as seguintes variáveis para execução dos exemplos abaixo:
- Menu > Integração > Criação de Credencial
string _clientId = "";
string _clientSecret = "";

- Menu > integração > token privado
string _privateToken = ""; // token de recurso

### Obtendo um token de acesso:
```
var auth = new JunoAuthorization(_clientId, _clientSecret);
var response = await auth.GenerateTokenAsync();
```

### Verificando o saldo na conta Juno:
```
var balance = new JunoBalance(tokenResponse.AccessToken, _privateToken);
var balanceResponse = await balance.GetBalanceAsync();
```


### Obter lista de cobranças:
```
var charge = new JunoCharge(tokenResponse.AccessToken, _privateToken);
var chargeResponse = await charge.GetCharges();
```

### Obter dados de uma cobrança específica:
```
var charge = new JunoCharge(tokenResponse.AccessToken, _privateToken);
var chargeResponse = await charge.GetCharge("{ID_DA_COBRANCA}");
```

### Gerar boleto de cobrança:
```
var charge = new JunoCharge(tokenResponse.AccessToken, _privateToken);
var body = new ChargeRequest
{
    Charge = new Charge
    {
        Description = "Descrição da Cobrança",
        References = new List<string> { "Referencia para identificação da cobrança" },
        Amount = 22.45, // valor da cobrança
        Fine = 3, // multa
        Interest = "2.4", // juros
        DueDate = DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"), // data de vencimento
        MaxOverdueDays = 3, // dias máximo para boleto vencido
        PaymentAdvance = true // permitir adiantamento do pagamento
    },
    Billing = new Billing
    {
        Name = "Joao da Silva", // Nome do destinatário para cobrança
        Document = "17849259939", // CPF
        Email = "email@dominio.com",
        Phone = "+5581732141290",
        BirthDate = "1968-03-21",
        Notify = true // Envia um e-mail para o usuário com a informação do boleto gerado
    }
};
var chargeResponse = await charge.GenerateBillingBillAsync(body);
```

### Cancelar boleto gerado
```
var charge = new JunoCharge(tokenResponse.AccessToken, _privateToken);
var chargeResponse = await charge.CancelBillingBillAsync("{ID_DA_COBRANCA}");
```
