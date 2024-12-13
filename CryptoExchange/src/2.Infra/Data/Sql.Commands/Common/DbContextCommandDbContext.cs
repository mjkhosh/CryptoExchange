using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Zamin.Extensions.Events.Outbox.Dal.EF;

namespace CryptoExchange.Infra.Data.Sql.Commands.Common
{
    public class DbContextCommandDbContext : BaseOutboxCommandDbContext
    {
        public DbContextCommandDbContext(DbContextOptions<DbContextCommandDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}