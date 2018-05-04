using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint06.Domain.Interfaces
{
    public interface IBirdRepository
    {
        int AddObservation(Observation bird);
        List<string> GetAllSpecies();
        List<Observation> GetAllObservations();
    }
}
