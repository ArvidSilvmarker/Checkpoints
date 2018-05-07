using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Checkpoint06.Domain;
using Checkpoint06.Domain.Interfaces;

namespace Checkpoint06.Infrastructure
{
    public class BirdRepository : IBirdRepository
    {
        private readonly ObservationContext _context = new ObservationContext();

        public int AddObservation(Observation bird)
        {
            _context.Observations.Add(bird);
            _context.SaveChanges();
            return bird.Id;
        }

        public List<string> GetAllSpecies()
        {
            var allSpecies = _context.Observations.Select(b => b.Species).Distinct().ToList();
            allSpecies.Sort();
            return allSpecies;
        }

        public List<Observation> GetAllObservations()
        {
            return _context.Observations.OrderBy(b => b.Time).ToList();
        }

    }
}
