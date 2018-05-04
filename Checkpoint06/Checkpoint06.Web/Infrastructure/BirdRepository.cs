using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkpoint06.Domain;
using Checkpoint06.Domain.Interfaces;

namespace Checkpoint06.Infrastructure
{
    public class BirdRepository : IBirdRepository
    {
        private ObservationContext _context = new ObservationContext();

        public int AddObservation(Observation bird)
        {
            _context.Observations.Add(bird);
            _context.SaveChanges();
            return bird.Id;
        }

        public List<string> GetAllSpecies()
        {
            return _context.Observations.Select(b => b.Species).Distinct().ToList();
        }

        public List<Observation> GetAllObservations()
        {
            return _context.Observations.OrderBy(b => b.Time).ToList();
        }

    }
}
