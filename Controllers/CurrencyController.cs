using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSofftek.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PruebaTecnicaSofftek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly CurrencyInformationService _currencyInformation;

        public CurrencyController(CurrencyInformationService currencyInformation)
        {
            _client = new HttpClient();
            _currencyInformation = currencyInformation;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrencyData([FromServices] CurrencyInformationService currencyInformation)
        {
            try
            {
                //Realiza una solicitud GET a la API de DolarAPI
                HttpResponseMessage responseUSD = await _client.GetAsync("https://dolarapi.com/v1/dolares/blue");
                HttpResponseMessage responseBTC = await _client.GetAsync("https://criptoya.com/api/banexcoin/btc/usd/0.1");

                if (responseUSD.IsSuccessStatusCode && responseBTC.IsSuccessStatusCode)
                {
                    // Lee y procesa la respuesta como JSON
                    string USDData = await responseUSD.Content.ReadAsStringAsync();
                    string BTCData = await responseBTC.Content.ReadAsStringAsync();

                    // Utiliza JsonDocument para analizar los datos JSON
                    using (JsonDocument usdDocument = JsonDocument.Parse(USDData))
                    using (JsonDocument btcDocument = JsonDocument.Parse(BTCData))
                    {
                        // Accede a los valores específicos en USD y BTC
                        decimal dolarPrice = usdDocument.RootElement.GetProperty("venta").GetDecimal();
                        decimal bitcoinPrice = btcDocument.RootElement.GetProperty("bid").GetDecimal();

                        // Puedes utilizar dolarPrice y bitcoinPrice según tus necesidades
                        currencyInformation.SetDolarInformation(dolarPrice);
                        currencyInformation.SetCryptoInformation(bitcoinPrice);
                        return Ok($"Valor del dólar: {dolarPrice}\nValor de Bitcoin: {bitcoinPrice}");
                    }
                }

                else
                {
                    return BadRequest("Error en la solicitud a la API de DolarAPI.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }
    }
}