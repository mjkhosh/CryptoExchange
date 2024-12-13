using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CryptoExchange.Infra.Data.Sql.Commands.Common
{
    public class DbContextCommandDbContextFactory : IDesignTimeDbContextFactory<DbContextCommandDbContext>
    {
        public DbContextCommandDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DbContextCommandDbContext>();

            builder.UseSqlServer("Server =.; Database=DbContextDb;User Id = ;Password = ; MultipleActiveResultSets = true; Encrypt = false");

            return new DbContextCommandDbContext(builder.Options);
        }
    }
}