using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace S3.Northwind.ValidationWebService
{
    public class PhoneNumberWebService
    {
        readonly string Key = "f8d2c7ffe26eb19cb7cdcb581be5cdf9";
        public bool ValidatePhoneNumber(string number)
        {
            string url = $"http://apilayer.net/api/validate?access_key={Key}&number={number}";
            try
            {
                Task<string> resultTask = CallWebApi(url);
                PhoneNumber phoneNumber = (PhoneNumber)UnpackFrom(resultTask.Result);
                return phoneNumber.Valid;
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

        private JsonPhoneNumber UnpackFrom(string json)
        {
            return JsonConvert.DeserializeObject<JsonPhoneNumber>(json);
        }

    }
}
