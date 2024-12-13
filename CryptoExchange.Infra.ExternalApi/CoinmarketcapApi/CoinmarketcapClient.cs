using CryptoExchange.Core.Contracts.Callers;
using CryptoExchange.Core.Domain.CoinMarketCapModels;
using RestSharp.Portable;

namespace CryptoExchange.Infra.ExternalApi.CoinmarketcapApi
{
    public class CoinmarketcapClient : ICoinmarketcapClient
    {
        private const string UrlBase = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/";
        private const string UrlBaseV2 = "https://pro-api.coinmarketcap.com/v2/cryptocurrency/";
        private const string UrlPartList = "listings/latest";
        private const string UrlPartItem = "quotes/latest";
        private string _ApiKey;

        public CoinmarketcapClient(string apiKey)
        {
            _ApiKey = apiKey;
        }
        List<string> ICoinmarketcapClient.GetConvertCurrencyList()
        {
            return new List<string> { "USD", "EUR", "BRL", "GBP", "AUD" };
        }


     

        Currency ICoinmarketcapClient.GetCurrencyBySymbol(string symbol)
        {
            return CurrencyBySymbolList(new List<string> { symbol }, symbol).First();
        }

       public  Currency GetCurrencyBySlug(string slug, string convertCurrency)
        {
            return CurrencyBySlugList(new List<string> { slug }, convertCurrency).First();
        }

        Currency ICoinmarketcapClient.GetCurrencyBySymbol(string symbol, string convertCurrency)
        {
            return CurrencyBySymbolList(new List<string> { symbol }, convertCurrency).First();
        }

        public IEnumerable<Currency> GetCurrencyBySlugList(string[] slugList)
        {
            return CurrencyBySlugList(slugList.ToList(), string.Empty);
        }

        public IEnumerable<Currency> GetCurrencyBySlugList(string[] slugList, string convertCurrency)
        {
            return CurrencyBySlugList(slugList.ToList(), convertCurrency);
        }


        private IEnumerable<Currency> CurrencyBySlugList(List<string> slugList, string convertCurrency)
        {
            var queryArguments = new Dictionary<string, string>
            {
                {"slug", string.Join(",", slugList.Select(item => item.ToLower()))}
            };

            var client = GetWebApiClient(UrlBaseV2, UrlPartItem, ref convertCurrency, queryArguments);
            var result = client.MakeRequest(Method.GET, convertCurrency, true, false, slugList);

            return result;
        }

        private IEnumerable<Currency> CurrencyBySymbolList(List<string> symbolList, string convertCurrency)
        {
            var queryArguments = new Dictionary<string, string>
            {
                {"symbol", string.Join(",", symbolList.Select(item => item.ToLower()))}
            };

            var client = GetWebApiClient(UrlBaseV2, UrlPartItem, ref convertCurrency, queryArguments);
            var result = client.MakeRequest(Method.GET, convertCurrency, true, true, symbolList);

            return result;
        }
        public IEnumerable<Currency> CurrenciesList(string convertCurrency)
        {
            return Currencies(-1, convertCurrency);

        }

        private WebApiClient GetWebApiClient(string baseUrl,
            string urlPart, ref string convertCurrency, Dictionary<string, string> queryArguments)
        {
            if (string.IsNullOrEmpty(convertCurrency))
                convertCurrency = "USD";

            queryArguments.Add("convert", convertCurrency);

            UriBuilder uri = new UriBuilder(baseUrl + urlPart);
            var client = new WebApiClient(uri, queryArguments, _ApiKey);
            return client;
        }

        IEnumerable<Currency> ICoinmarketcapClient.GetCurrencies()
        {
            return Currencies(-1, string.Empty);
        }

        IEnumerable<Currency> ICoinmarketcapClient.GetCurrencies(string convertCurrency)
        {
            return Currencies(-1, convertCurrency);
        }

        IEnumerable<Currency> ICoinmarketcapClient.GetCurrencies(int limit)
        {
            return Currencies(limit, string.Empty);
        }

        IEnumerable<Currency> ICoinmarketcapClient.GetCurrencies(int limit, string convertCurrency)
        {
            return Currencies(limit, convertCurrency);
        }

        private List<Currency> Currencies(int limit, string convertCurrency)
        {
            var queryArguments = new Dictionary<string, string>
            {
                {"start", "1"}
            };

            if (limit > 0)
                queryArguments.Add("limit", limit.ToString());
            else
                queryArguments.Add("limit", "150");

            var client = GetWebApiClient(UrlBase, UrlPartList, ref convertCurrency, queryArguments);

            var result = client.MakeRequest(Method.GET, convertCurrency, false, false, new List<string>());
            return result;
        }
    }
}
