using CryptoExchange.Core.RequestResponse.Exchange.Queries;
using Microsoft.AspNetCore.Mvc;
namespace CryptoExchange.Endpoints.API.Exchange
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : BaseController
    {
        #region Queries
        [HttpPost("GetByName")]
        public async Task<IActionResult> GetByName([FromBody] GetExchangeByNameQuery query) => await Query<GetExchangeByNameQuery, ExchangeDetailQr?>(query);
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll(GetAllExchangeQuery query) => await Query<GetAllExchangeQuery, List<ExchangeInfoQr?>>(query);

        #endregion
    }
}
