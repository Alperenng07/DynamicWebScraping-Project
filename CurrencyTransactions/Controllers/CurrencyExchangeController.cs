using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Globalization;
using DataAccess;
using Entities.Entity;

namespace CurrencyExchangeApi.Controllers
{
    [ApiController]
    [Route("api/currencyexchange")]
    public class CurrencyExchangeController : ControllerBase
    {
        readonly CultureInfo culture = new("en-US");
        private readonly DataContext _dbContext;
        private readonly IConfiguration _configuration;

        public CurrencyExchangeController(DataContext context, IConfiguration configuration)
        {
            _dbContext = context;
            _configuration = configuration;
        }

        [HttpGet("getexchange/{date}")]
        public async Task<IActionResult> GetExchangeRatesAsync(DateTime date)
        {
            try
            {
                if (date == default)
                {
                    return BadRequest("Tarih parametresi geçerli bir tarih olmalıdır.");
                }

                string url = $"https://www.tcmb.gov.tr/kurlar/{date:yyyy-MM-dd}.xml";

                var httpClient = new HttpClient();
                var result = await httpClient.GetAsync(url);


                if (result.IsSuccessStatusCode==true)
                {
                    var xmlContent = await result.Content.ReadAsStringAsync();

                    XDocument xmlDoc = XDocument.Parse(xmlContent);

                    // Düzgün bir şekilde FCurrency sınıfını tanımlayın ve bu sınıfa göre verileri çekin

                    // Örnek:
                    // Date parametresi ile verileri filtreleyerek ExchangeRate tablosundan verileri çekin
                    var exchangeRates = _dbContext.ExchangeRates
                        .Where(e => e.Date == )
                        .ToList();

                    return Ok(exchangeRates);

                    // currencies listesini veritabanına kaydedin
                    // _dbContext.FCurrencies.AddRange(currencies);
                    // await _dbContext.SaveChangesAsync();

                   // return Ok("Kurlar başarıyla çekildi ve kaydedildi.");
                }
                else
                {
                    return BadRequest($"HTTP isteği, durum kodu {result.StatusCode} ile başarısız oldu.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

        // Diğer endpoint'leri ekleyin

        // ...
    }
}
