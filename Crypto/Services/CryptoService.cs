using Crypto.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Services
{
    public class CoincapService
    {
        public List<Models.CoincapAssetModel> Assets { get  {
                var response = httpClient.GetAsync("/v2/assets").Result;
                var result = response.Content.ReadAsStringAsync().Result;

                var data = JsonConvert.DeserializeObject<Models.CoincapAssetDataModel>(result);

                return data.Data;
         } }
        
        private readonly HttpClient httpClient;

        public CoincapService()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.coincap.io"),
            };
        }

        public async Task<CoincapAssetModel> GetCoincapAsync(CoincapRequestModel model)
        {
            var response = await httpClient.GetAsync($"/v2/assets/{model.Name}/history?interval=d1");
            var result = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<Models.CoincapAssetModel>(result);

            return data;
        }

        
    }
}
