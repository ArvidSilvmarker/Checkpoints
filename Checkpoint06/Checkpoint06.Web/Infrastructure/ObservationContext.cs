using Microsoft.EntityFrameworkCore;
using Checkpoint06.Domain;

namespace Checkpoint06.Infrastructure

{
    public class ObservationContext :DbContext
    {
        public DbSet<Observation> Observations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=BirdObservations.db");
        }
    }
}

