using CryptoExchange.Core.RequestResponse.BaseFramework;

namespace CryptoExchange.Core.RequestResponse.Common
{
    public sealed class QueryResult<TData> : ApplicationServiceResult
    {
        public TData? _data;

        public TData? Data => _data;
    }
}
