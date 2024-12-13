using CryptoExchange.Core.Domain.CoinMarketCapModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExchange.Core.Contracts.Callers
{
    public interface ICoinmarketcapClient
    {
        List<string> GetConvertCurrencyList();
        Currency GetCurrencyBySymbol(string symbol);
        Currency GetCurrencyBySlug(string slug, string convertCurrency);
        Currency GetCurrencyBySymbol(string symbol, string convertCurrency);
        IEnumerable<Currency> GetCurrencyBySlugList(string[] slugList);
        IEnumerable<Currency> GetCurrencyBySlugList(string[] slugList, string convertCurrency);

        IEnumerable<Currency> GetCurrencies();
        IEnumerable<Currency> GetCurrencies(string convertCurrency);
        IEnumerable<Currency> GetCurrencies(int limit);
        IEnumerable<Currency> GetCurrencies(int limit, string convertCurrency);
    }
}
