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
    public class HistoryRateService
    {
        private readonly HttpClient httpClient;

        public HistoryRateService()
        {
            this.httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.coincap.io");
        }

        public async Task<List<Models.HistoryRateModel>> GetHistoryAsync(string assetId)
        {
             return await httpClient.GetAsync($"/v2/assets/{assetId}/history?interval=d1")
                 .ContinueWith(task => task.Result.Content.ReadAsStringAsync())
                 .Unwrap()
                 .ContinueWith(task => {
                     var response = JsonConvert.DeserializeObject<HistoryRateDataModel>(task.Result);
                     return response.Data;
                 });    
        }
    }
}
