using CryptoExchange.Core.Contracts.Callers;
using CryptoExchange.Core.RequestResponse.BaseFramework;
using CryptoExchange.Infra.ExternalApi.CoinmarketcapApi;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyModel;
using Newtonsoft.Json.Converters;
using System.Reflection;

namespace CryptoExchange.Endpoints.API.Extentions
{
    public static class HostingExtensions
    {
        #region Extentions
        private static IServiceCollection AddDependencies(this IServiceCollection services, params string[] assemblyNamesForSearch)
        {
            List<Assembly> assemblies = GetAssemblies(assemblyNamesForSearch);
            services.AddApplicationServices(assemblies).AddCallerDepenecies(assemblies)
                .AddCustomDepenecies(assemblies);
            return services;
        }
        private static List<Assembly> GetAssemblies(string[] assmblyName)
        {
            List<Assembly> list = new List<Assembly>();
            foreach (RuntimeLibrary runtimeLibrary in DependencyContext.Default.RuntimeLibraries)
            {
                if (IsCandidateCompilationLibrary(runtimeLibrary, assmblyName))
                {
                    Assembly item = Assembly.Load(new AssemblyName(runtimeLibrary.Name));
                    list.Add(item);
                }
            }

            return list;
        }
        public static IServiceCollection AddCustomDepenecies(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            return services.AddWithTransientLifetime(assemblies, typeof(ITransientLifetime))
                .AddWithScopedLifetime(assemblies, typeof(IScopeLifetime));
        }
        public static IServiceCollection AddCallerDepenecies(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            return services.AddTransient< ICoinMarketCapCaller, CoinMarketCapCaller>();
        }        
        private static bool IsCandidateCompilationLibrary(RuntimeLibrary compilationLibrary, string[] assmblyName)
        {
            if (!assmblyName.Any((string d) => compilationLibrary.Name.Contains(d)))
            {
                return compilationLibrary.Dependencies.Any((Dependency d) => assmblyName.Any((string c) => d.Name.Contains(c)));
            }

            return true;
        }
        public static IServiceCollection AddWithTransientLifetime(this IServiceCollection services,
            IEnumerable<Assembly> assembliesForSearch,
            params Type[] assignableTo)
                    {
            services.Scan(s => s.FromAssemblies(assembliesForSearch)
                .AddClasses(c => c.AssignableToAny(assignableTo))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
            return services;
        }
        public static IServiceCollection AddWithScopedLifetime(this IServiceCollection services,
           IEnumerable<Assembly> assembliesForSearch,
           params Type[] assignableTo)
        {
            services.Scan(s => s.FromAssemblies(assembliesForSearch)
                .AddClasses(c => c.AssignableToAny(assignableTo))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            return services;
        }

        public static IServiceCollection AddWithSingletonLifetime(this IServiceCollection services,
            IEnumerable<Assembly> assembliesForSearch,
            params Type[] assignableTo)
        {
            services.Scan(s => s.FromAssemblies(assembliesForSearch)
                .AddClasses(c => c.AssignableToAny(assignableTo))
                .AsImplementedInterfaces()
                .WithSingletonLifetime());
            return services;
        }
        #endregion
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            IConfiguration configuration = builder.Configuration;

            builder.Services.AddControllers();
            builder.Services.AddDependencies("CryptoExchange");
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
        options.SerializerSettings.Converters.Add(new StringEnumConverter()));
            builder.Services.AddSwaggerGenNewtonsoftSupport();

         
            builder.Services.AddSwaggerGen();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStatusCodePages();

            app.UseCors(delegate (CorsPolicyBuilder builder)
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });
            app.UseHttpsRedirection();
            var controllerBuilder = app.MapControllers();
            return app;
        }
    }
}