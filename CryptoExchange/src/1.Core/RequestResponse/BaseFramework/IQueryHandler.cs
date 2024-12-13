using CryptoExchange.Core.RequestResponse.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExchange.Core.RequestResponse.BaseFramework
{
    public interface IQueryHandler<TQuery, TData> where TQuery : class, IQuery<TData>
    {
        Task<QueryResult<TData>> Handle(TQuery request);
    }
}
