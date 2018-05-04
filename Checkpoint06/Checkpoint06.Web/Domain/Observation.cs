using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint06.Domain
{
    public class Observation
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public string Location { get; set; }
        public DateTime Time { get; set; }
        public string Notes { get; set; }
    }
}
