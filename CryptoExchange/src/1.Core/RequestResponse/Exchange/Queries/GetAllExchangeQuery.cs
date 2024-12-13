using CryptoExchange.Core.RequestResponse.BaseFramework;
using CryptoExchange.Core.RequestResponse.Common;

namespace CryptoExchange.Core.RequestResponse.Exchange.Queries
{
    public class GetAllExchangeQuery : IQuery<List<ExchangeInfoQr?>>
    {
        public CurrencyType currencyType { get; set; }
    }

}
