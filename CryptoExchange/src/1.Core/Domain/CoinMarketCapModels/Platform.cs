﻿namespace CryptoExchange.Infra.ExternalApi.CoinmarketcapApi
{
    public class Platform
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string slug { get; set; }
        public string token_address { get; set; }
    }
}
