using Microsoft.EntityFrameworkCore;
using Space.Domain;

namespace Space.Data
{
    public class SpaceContext : DbContext
    {
        public DbSet<Spaceship> Spaceships { get; set; }
        //public DbSet<Ravioli> Ravioli { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = Spaceships; Trusted_Connection = True; ");
        }
    }
}