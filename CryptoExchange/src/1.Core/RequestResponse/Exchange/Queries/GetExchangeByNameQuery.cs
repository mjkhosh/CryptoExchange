using CryptoExchange.Core.RequestResponse.BaseFramework;
using CryptoExchange.Core.RequestResponse.Common;

namespace CryptoExchange.Core.RequestResponse.Exchange.Queries
{
    public class GetExchangeByNameQuery : IQuery<ExchangeDetailQr?>
    {
        public string cryptoName { get; set; }
        public CurrencyType currencyType { get; set; }

    }
}
