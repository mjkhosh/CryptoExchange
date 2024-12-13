using CryptoExchange.Core.Contracts.Callers;
using CryptoExchange.Core.Domain.CoinMarketCapModels;



namespace CryptoExchange.Infra.ExternalApi.CoinmarketcapApi
{

    public class CoinMarketCapCaller : ICoinMarketCapCaller
    {
        private readonly CoinmarketcapClient _coinmarketcapClient;
        private static string API_KEY = "dc55871d-e0e5-46e1-8521-da33c54d1357";

        public CoinMarketCapCaller()
        {
            _coinmarketcapClient = new CoinmarketcapClient(API_KEY);
        }
        public async Task<List<Currency>> GetListOfCryptoCurrency(string CurrencyType)
        {
            return await Task.Run(() => _coinmarketcapClient.CurrenciesList(CurrencyType).ToList());
        }
        public async Task<Currency> GetCryptoCurrency(string CryptoName,string CurrencyType)
        {
            return await Task.Run(() => _coinmarketcapClient.GetCurrencyBySlug(CryptoName, CurrencyType));
        }
    }
}


