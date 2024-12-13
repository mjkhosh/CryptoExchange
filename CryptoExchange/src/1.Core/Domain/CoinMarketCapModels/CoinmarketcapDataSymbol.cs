namespace CryptoExchange.Infra.ExternalApi.CoinmarketcapApi
{
    public class CoinmarketcapDataSymbol
    {
        public DataItemSymbol dataItem { get; set; } = new();
        public CoinmarketcapItemData status { get; set; } = new();

    }
}
