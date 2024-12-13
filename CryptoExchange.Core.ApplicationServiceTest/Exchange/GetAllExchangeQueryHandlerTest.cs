using CryptoExchange.Core.ApplicationService.Exchange.Queries.GetAll;
using CryptoExchange.Core.ApplicationServiceTest.Exchange.Attributes;
using CryptoExchange.Core.Contracts.Callers;
using CryptoExchange.Core.RequestResponse.Exchange.Queries;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExchange.Core.ApplicationServiceTest.Exchange
{
    public class GetAllExchangeQueryHandlerTest
    {
        private readonly Mock<ICoinMarketCapCaller> _coinMarketCapCaller;
        private readonly GetAllExchangeQueryHandler _handler;
        public GetAllExchangeQueryHandlerTest()
        {
            _coinMarketCapCaller = new Mock<ICoinMarketCapCaller>();
            _handler = new GetAllExchangeQueryHandler(_coinMarketCapCaller.Object);
        }
        [Theory]
        [Trait("Exchange", "Get")]
        [GetAllDataHandlerValidData]
        public async Task When_CurrencyType_Is_valid(CryptoExchange.Core.RequestResponse.Common.CurrencyType CurrencyType)
        {
            GetAllExchangeQuery query = new GetAllExchangeQuery() { currencyType = CurrencyType };
            _coinMarketCapCaller.Setup(x => x.GetListOfCryptoCurrency(CurrencyType.ToString())).ReturnsAsync(new
                List<Domain.CoinMarketCapModels.Currency>()
            { 
                
            });
           await  _handler.Handle(query);
        }
        [Theory]
        [Trait("Exchange", "Get")]
        [GetAllDataHandlerInValidData]
        public async Task When_CurrencyType_Is_Invalid(CryptoExchange.Core.RequestResponse.Common.CurrencyType CurrencyType)
        {
            GetAllExchangeQuery query = new GetAllExchangeQuery() { currencyType = CurrencyType };
            _coinMarketCapCaller.Setup(x => x.GetListOfCryptoCurrency(CurrencyType.ToString())).ReturnsAsync(new
                List<Domain.CoinMarketCapModels.Currency>()
            {

            });
            await _handler.Handle(query);
        }
    }
}
