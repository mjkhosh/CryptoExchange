namespace CryptoExchange.Core.RequestResponse.BaseFramework
{
    public class CommandResult : ApplicationServiceResult
    {
    }
    public class CommandResult<TData> : CommandResult
    {
        public TData? _data;

        public TData? Data => _data;
    }

}
