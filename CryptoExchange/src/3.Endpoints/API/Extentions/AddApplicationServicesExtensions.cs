using System.Reflection;
using CryptoExchange.Core.RequestResponse.BaseFramework;
namespace CryptoExchange.Endpoints.API.Extentions
{
    public static class AddApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
                                                                     IEnumerable<Assembly> assembliesForSearch)
            => services.AddCommandHandlers(assembliesForSearch)
                              .AddCommandDispatcherDecorators()

                       .AddQueryHandlers(assembliesForSearch).AddQueryDispatcherDecorators();
                      
                     

        private static IServiceCollection AddCommandHandlers(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch)
            => services.AddWithTransientLifetime(assembliesForSearch, typeof(ICommandHandler<>), typeof(ICommandHandler<,>));

      

        private static IServiceCollection AddQueryHandlers(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch)
            => services.AddWithTransientLifetime(assembliesForSearch, typeof(IQueryHandler<,>));

        private static IServiceCollection AddCommandDispatcherDecorators(this IServiceCollection services)
        {
            services.AddTransient<CommandDispatcher, CommandDispatcher>();
            services.AddTransient<ICommandDispatcher>(c =>
            {
                var commandDispatcher = c.GetRequiredService<CommandDispatcher>();
               
                return commandDispatcher;
            });
            return services;
        }
        private static IServiceCollection AddQueryDispatcherDecorators(this IServiceCollection services)
        {
            services.AddTransient<QueryDispatcher, QueryDispatcher>();
            services.AddTransient<IQueryDispatcher>(c =>
            {
                var queryDispatcher = c.GetRequiredService<QueryDispatcher>();
                return queryDispatcher;

            });
                return services;
        }


    }
}
