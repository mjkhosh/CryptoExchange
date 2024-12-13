using CryptoExchange.Core.RequestResponse.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExchange.Core.RequestResponse.BaseFramework
{
    public class QueryDispatcher : IQueryDispatcher
    {
        #region Fields
        private readonly IServiceProvider _serviceProvider;
        #endregion

        #region Constructors
        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        #endregion

        #region Query Dispatcher
        public Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query) where TQuery : class, IQuery<TData>
        {
            try
            {
                var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TData>>();
                return handler.Handle(query);
            }
            catch (InvalidOperationException ex)
            {
                throw;
            }
            finally
            {
            }
        }
        #endregion
    }
}
