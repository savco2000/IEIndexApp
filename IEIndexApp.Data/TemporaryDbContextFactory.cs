using IEIndexApp.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace IEIndexApp.Data
{
    public class TemporaryDbContextFactory : IDbContextFactory<IEIndexContext>
    {
        public IEIndexContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<IEIndexContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=IEIndex;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new IEIndexContext(builder.Options);
        }
    }
}