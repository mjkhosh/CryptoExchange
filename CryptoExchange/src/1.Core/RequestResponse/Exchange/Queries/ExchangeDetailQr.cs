using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExchange.Core.RequestResponse.Exchange.Queries
{
    public class ExchangeDetailQr
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
        public decimal Price { get; set; }
        public DateTime LastUpdated { get; set; }
        public decimal Volume24hUsd { get; set; }
        public decimal MarketCapUsd { get; set; }
        public decimal PercentChange1h { get; set; }
        public decimal PercentChange24h { get; set; }
        public decimal PercentChange7d { get; set; }
        public decimal MarketCapConvert { get; set; }

    }
}
