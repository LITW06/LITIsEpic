using Microsoft.EntityFrameworkCore;

namespace LITIsEpic.Data
{
    public class LitIsEpicContext : DbContext
    {
        private string _connectionString;

        public LitIsEpicContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Visit> Visits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connectionString);
        }
    }
}