using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Models
{
    public class CoincapAssetDataModel
    {
        public List<CoincapAssetModel> Data { get; set; }
    }

    public partial class CoincapAssetModel
    {
        public string? Id { get; set; }
        public string? Rank { get; set; }
        public string? Symbol { get; set; }
        public string? Name { get; set; }
        public string? Supply { get; set; }
        public double? MaxSupply { get; set; }
        public double MarketCapUsd { get; set; }
        public double VolumeUsd24Hr { get; set; }
        public double PriceUsd { get; set; }
        public double ChangePercent24Hr { get; set; }
        public double? Vwap24Hr { get; set; }
        public string? Explorer { get; set; }
    }
    /*{ 
id: "ethereum", 
rank: "2", 
symbol: "ETH", 
name: "Ethereum", 
supply: "121331416.0615000000000000", 
maxSupply: null, 
marketCapUsd: "148569300597.6975384170989497", 
volumeUsd24Hr: "6083962773.9980685896237432", 
priceUsd: "1224.4916067112519696", 
changePercent24Hr: "0.7711275909226340", 
vwap24Hr: "1200.0086625397174458", 
explorer: "https://etherscan.io/" 
},*/
}
