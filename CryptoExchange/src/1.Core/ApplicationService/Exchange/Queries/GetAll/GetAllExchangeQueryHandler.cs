using CryptoExchange.Core.Contracts.Callers;
using CryptoExchange.Core.RequestResponse.BaseFramework;
using CryptoExchange.Core.RequestResponse.Common;
using CryptoExchange.Core.RequestResponse.Exchange.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExchange.Core.ApplicationService.Exchange.Queries.GetAll
{
    public class GetAllExchangeQueryHandler : QueryHandler<GetAllExchangeQuery, List<ExchangeInfoQr?>>
    {
        private readonly ICoinMarketCapCaller _coinMarketCapCaller;
        public GetAllExchangeQueryHandler(ICoinMarketCapCaller coinMarketCapCaller)
        {
            _coinMarketCapCaller = coinMarketCapCaller;
        }

        public override async Task<QueryResult<List<ExchangeInfoQr?>>> Handle(GetAllExchangeQuery query)
        {
            var t = await _coinMarketCapCaller.GetListOfCryptoCurrency(query.currencyType.ToString());
            List<ExchangeInfoQr> ExchangeQr = t.Select(x => new ExchangeInfoQr()
            {
                Id = x.Id,
                Name = x.Name,
                LastUpdated = x.LastUpdated,
                Price = x.Price,
                Rank = Convert.ToInt32( x.Rank)
            }).OrderBy(x=>x.Rank)
               .ToList();
            return Result(ExchangeQr);
        }
    }
}
