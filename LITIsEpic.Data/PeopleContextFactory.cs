using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LITIsEpic.Data
{
    public class PeopleContextFactory : IDesignTimeDbContextFactory<LitIsEpicContext>
    {
        public LitIsEpicContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}LITIsEpic.Web"))
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true).Build();

            return new LitIsEpicContext(config.GetConnectionString("ConStr"));
        }
    }
}