﻿namespace CryptoExchange.Infra.ExternalApi.CoinmarketcapApi
{
    public class CurrenyData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string slug { get; set; }
        public int num_market_pairs { get; set; }
        public DateTime date_added { get; set; }
        public List<Tag> tags { get; set; }
        public object max_supply { get; set; }
        public double circulating_supply { get; set; }
        public double total_supply { get; set; }
        public int is_active { get; set; }
        public bool infinite_supply { get; set; }

        public Platform? platform { get; set; }
        public int? cmc_rank { get; set; }
        public int is_fiat { get; set; }
        public object self_reported_circulating_supply { get; set; }
        public object self_reported_market_cap { get; set; }
        public object tvl_ratio { get; set; }
        public DateTime last_updated { get; set; }
        public Quote quote { get; set; }
    }
}
