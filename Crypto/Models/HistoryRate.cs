using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Models
{
    public class HistoryRateDataModel
    {
        [JsonProperty("data")]
        public List<HistoryRateModel> Data { get; set; }
    }

    public class HistoryRateModel
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("time")]
        public long Time { get; set; }
        [JsonProperty("priceUsd")]
        public double Price { get; set; }
    }
}
