using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint07.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {
            Name = RandomizeName();
            Age = RandomizeAge();
        }

        private int RandomizeAge()
        {
            return new Random().Next(1, 101); //Jag tolkar "mellan 1-100" som inklusive 1 och 100.
        }

        private string RandomizeName()
        {
            var nameList = new List<string>
            {
                "Vilmer",
                "Lily",
                "Tim",
                "Aurora",
                "Wilhelm",
                "Matheo",
                "Nick",
                "Jessica",
                "Noomi",
                "Elton",
                "Isolde",
                "Alva",
                "Frode",
                "Berthold"
            };
            var random = new Random();
            return nameList[random.Next(0, nameList.Count)];
        }

        public string PersonToString()
        {
            return $"{Name} {Age} år";
        }
    }
}
