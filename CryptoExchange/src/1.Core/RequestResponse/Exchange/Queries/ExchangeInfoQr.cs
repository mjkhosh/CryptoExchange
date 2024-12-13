namespace CryptoExchange.Core.RequestResponse.Exchange.Queries;

public class ExchangeInfoQr
{
    public string Id { get; set; }
    public string  Name { get; set; }
    public int Rank { get; set; }
    public decimal Price { get; set; }
    public DateTime LastUpdated { get; set; }

}
