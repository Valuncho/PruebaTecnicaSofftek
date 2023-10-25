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

        public CurrencyController()
        {
            _client = new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrencyData([FromServices] CurrencyInformationService currencyInformation)
        {
            try
            {
                // Realiza una solicitud GET a la API de DolarAPI
                HttpResponseMessage responseUSD = await _client.GetAsync("https://dolarapi.com/v1/dolares/blue");
                HttpResponseMessage responseBTC = await _client.GetAsync("https://criptoya.com/api/banexcoin/btc/usd/0.1");

                if (responseUSD.IsSuccessStatusCode && responseBTC.IsSuccessStatusCode)
                {
                    // Lee y procesa la respuesta como JSON
                    string USDData = await responseUSD.Content.ReadAsStringAsync();
                    var dolarSplitted = USDData.Split(',');
                    var dolarValue = dolarSplitted[4];
                    decimal dolarPrice = 
                    Console.Write(dolarPrice);
                    string BTCData = await responseBTC.Content.ReadAsStringAsync();
                    currencyInformation.SetDolarInformation(USDData);
                    currencyInformation.SetCryptoInformation(BTCData);
                    return Ok(USDData +"\n"+ BTCData);
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