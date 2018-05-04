using Microsoft.EntityFrameworkCore;

namespace Checkpoint06.Web.Models
{
    public class ObservationContext :DbContext
    {
        // public DbSet<Observation> Observations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=BirdObservations.db");
        }
    }
}

