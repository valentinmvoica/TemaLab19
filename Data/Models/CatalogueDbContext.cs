using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    internal class CatalogueDbContext : DbContext
    {
        private readonly string connectionString;
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public CatalogueDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.connectionString);
        }

    }
}
