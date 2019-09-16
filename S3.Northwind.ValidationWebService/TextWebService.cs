using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace S3.Northwind.ValidationWebService
{
    public class TextWebService
    {
        private readonly string urlContainsProfanity = "https://www.purgomalum.com/service/containsprofanity?text=";
        private readonly string urlJson = "https://www.purgomalum.com/service/json?text=";
        public bool ContainsProfanity(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }
            Task<string> resultTask = CallWebApi(urlContainsProfanity + text);
            bool containsProfanity = ConvertToBool(resultTask.Result);
            return containsProfanity;
        }

        private async Task<string> CallWebApi(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(url).ConfigureAwait(false);
            }
        }

        private bool ConvertToBool(string result)
        {
            return bool.Parse(result);
        }

        private JsonText UnpackFrom(string json)
        {
            return JsonConvert.DeserializeObject<JsonText>(json);
        }

        public (string returnText, bool containsProfanity) CheckForProfanity(string text)
        {
            Task<string> resultTask = CallWebApi(urlJson + text);
            JsonText jsonText = UnpackFrom(resultTask.Result);

            TextWebService textWebService = new TextWebService();
            if (textWebService.ContainsProfanity(text))
            {
                return (jsonText.Result, true);
            }
            else
            {
                return (jsonText.Result, false);
            }
        }
    }
}
