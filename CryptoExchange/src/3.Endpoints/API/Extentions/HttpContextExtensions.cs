using CryptoExchange.Core.RequestResponse.BaseFramework;

namespace CryptoExchange.Endpoints.API.Extentions
{
    public static class HttpContextExtension
    {
        public static ICommandDispatcher CommandDispatcher(this HttpContext httpContext)
        {
            return (ICommandDispatcher)httpContext.RequestServices.GetService(typeof(ICommandDispatcher));
        }

        public static IQueryDispatcher QueryDispatcher(this HttpContext httpContext)
        {
            return (IQueryDispatcher)httpContext.RequestServices.GetService(typeof(IQueryDispatcher));
        }
    }

}
