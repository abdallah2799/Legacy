using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Data
{
    public  class LegacyDbContextFactory : IDesignTimeDbContextFactory<LegacyDbContext>
    {
        public LegacyDbContext CreateDbContext(string[] args)
        {
            // هنا بنقرأ appsettings.json يدوي
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<LegacyDbContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            return new LegacyDbContext(optionsBuilder.Options);
        }
    }
}
