using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Space.Domain;
using Space.Data;

namespace Space.Program
{
    public class SpaceHandler
    {
        public void RecreateDatabase()
        {
            using (var context = new SpaceContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }

        public void AddSpaceship(string spaceshipName)
        {
            using (var context = new SpaceContext())
            {
                context.Spaceships.Add(new Spaceship {Name = spaceshipName});
                context.SaveChanges();
            }
        }

        public List<Spaceship> GetAllSpaceships()
        {
            using (var context = new SpaceContext())
            {
                return context.Spaceships.Include(s => s.Ravioli).ToList();        
            }
        }

        public void AddRavioliForSpaceship(string spaceshipName, int numberOfRavioli, string dateString)
        {
            using (var context = new SpaceContext())
            {
                var spaceship = context.Spaceships.FirstOrDefault(s => s.Name == spaceshipName);
                if (spaceship != null)
                {
                    spaceship.AddRavioli(numberOfRavioli, dateString);
                    context.Update(spaceship);
                    context.SaveChanges();
                }

            }
        }
    }
}
