using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WarehouseManagement.Infrastructure
{
    public class DbFactory : IDesignTimeDbContextFactory<WarehouseContext>
    {
        public WarehouseContext CreateDbContext(string[] args)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=WarehouseContext;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new WarehouseContext(optionsBuilder.Options);
        }
    }
}