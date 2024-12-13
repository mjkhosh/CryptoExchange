namespace CryptoExchange.Core.RequestResponse.Common
{
    public enum ApplicationServiceStatus
    {
        Ok = 1,
        NotFound,
        ValidationError,
        InvalidDomainState,
        Exception
    }
}
