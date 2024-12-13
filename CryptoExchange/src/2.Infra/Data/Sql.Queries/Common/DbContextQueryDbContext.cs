using Microsoft.EntityFrameworkCore;
using Zamin.Infra.Data.Sql.Queries;

namespace CryptoExchange.Infra.Data.Sql.Queries.Common
{
    public class DbContextQueryDbContext : BaseQueryDbContext
    {
        public DbContextQueryDbContext(DbContextOptions<DbContextQueryDbContext> options) : base(options)
        {
        }
    }
}