using CryptoExchange.Core.Contracts.Callers;
using CryptoExchange.Core.RequestResponse.BaseFramework;
using CryptoExchange.Core.RequestResponse.Common;
using CryptoExchange.Core.RequestResponse.Exchange.Queries;


namespace CryptoExchange.Core.ApplicationService.Exchange.Queries.GetByName
{
    public class GetExchangeByNameQueryHandler : QueryHandler<GetExchangeByNameQuery, ExchangeDetailQr?>
    {
        private readonly ICoinMarketCapCaller _coinMarketCapCaller;
        public GetExchangeByNameQueryHandler(ICoinMarketCapCaller coinMarketCapCaller)
        {
            _coinMarketCapCaller = coinMarketCapCaller;
        }

        public override async Task<QueryResult<ExchangeDetailQr?>> Handle(GetExchangeByNameQuery query)
        {
            var res = await _coinMarketCapCaller.GetCryptoCurrency(query.cryptoName, query.currencyType.ToString());
            ExchangeDetailQr detailQr = new()
            {
                Id = res.Id,
                LastUpdated = res.LastUpdated,
                MarketCapConvert = res.MarketCapConvert,
                MarketCapUsd = res.MarketCapUsd,
                Name = res.Name,
                PercentChange1h = res.PercentChange1h,
                PercentChange24h = res.PercentChange24h,
                PercentChange7d = res.PercentChange7d,
                Price = res.Price,
                Rank = Convert.ToInt32(res.Rank),
                Volume24hUsd = res.Volume24hUsd
            };
            return Result(detailQr);
        }
    }
}
