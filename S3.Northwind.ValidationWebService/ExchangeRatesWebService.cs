using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace S3.Northwind.ValidationWebService
{
    public class ExchangeRatesWebService
    {
        public ExchangeRates GetCurrencies(string Key = "9c3fc336626140c5b410e390c47acc95")
        {
            string url = $"https://openexchangerates.org/api/latest.json?app_id={Key}";
            try
            {
                Task<string> resultTask = CallWebApi(url);
                ExchangeRates exchangeRates = UnpackFrom(resultTask.Result);
                return exchangeRates;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<string> CallWebApi(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(url).ConfigureAwait(false);
            }
        }

        private ExchangeRates UnpackFrom(string json)
        {
            return JsonConvert.DeserializeObject<ExchangeRates>(json);
        }
    }
}
