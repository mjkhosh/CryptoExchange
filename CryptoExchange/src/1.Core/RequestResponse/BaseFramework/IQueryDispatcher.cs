using CryptoExchange.Core.RequestResponse.Common;


namespace CryptoExchange.Core.RequestResponse.BaseFramework
{
    public interface IQueryDispatcher
    {
        Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query) where TQuery : class, IQuery<TData>;
    }
}
