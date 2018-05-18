using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkpoint07.Domain;
using Microsoft.EntityFrameworkCore;

namespace Checkpoint07.Infrastructure
{
    public class NameContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=tcp:sql-checkpoint07arvidsilvmarker-dev.database.windows.net,1433;Initial Catalog=db-checkpoint07arvidsilvmarker-dev;Persist Security Info=False;User ID=ServerAdmin;Password=Checkpoint07;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }
    }
}
