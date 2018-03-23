using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;

namespace Checkpoint02.ArvidSilvmarker
{
    class Room
    {
        public string Name { get; set; }
        public int Area { get; set; }
        public bool LightsOn { get; set; }

        public Room(string name, int area, bool lightsOn)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new NullReferenceException("Rummet måste ha ett namn.");
            Name = name;

            if (area <= 0)
                throw new ArgumentException("Rummet måste ha yta > 0.");
            Area = area;

            LightsOn = lightsOn;
        }
    }
}
