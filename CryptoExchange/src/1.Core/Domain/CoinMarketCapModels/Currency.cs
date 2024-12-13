using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExchange.Core.Domain.CoinMarketCapModels
{
    public class Currency
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Rank { get; set; }
        public decimal Price { get; set; }
        public decimal Volume24hUsd { get; set; }
        public decimal MarketCapUsd { get; set; }
        public decimal PercentChange1h { get; set; }
        public decimal PercentChange24h { get; set; }
        public decimal PercentChange7d { get; set; }
        public DateTime LastUpdated { get; set; }
        public decimal MarketCapConvert { get; set; }
        public string ConvertCurrency { get; set; }
    }
}
