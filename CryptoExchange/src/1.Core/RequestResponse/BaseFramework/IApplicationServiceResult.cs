using CryptoExchange.Core.RequestResponse.Common;

namespace CryptoExchange.Core.RequestResponse.BaseFramework
{
    internal interface IApplicationServiceResult
    {
        IEnumerable<string> Messages { get; }
        ApplicationServiceStatus Status { get; }
    }
}
