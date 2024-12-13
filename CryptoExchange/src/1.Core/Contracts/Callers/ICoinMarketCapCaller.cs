using CryptoExchange.Core.Domain.CoinMarketCapModels;
using CryptoExchange.Core.RequestResponse.BaseFramework;

namespace CryptoExchange.Core.Contracts.Callers
{
    public interface ICoinMarketCapCaller: ICaller
    {
        Task<List<Currency>> GetListOfCryptoCurrency(string CurrencyType);
        Task<Currency> GetCryptoCurrency(string CryptoName, string CurrencyType);
    }
}
