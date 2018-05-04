using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Domain
{
    public class Spaceship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Ravioli> Ravioli { get; set; }

        public void AddRavioli(int numberOfRavioli, string dateString)
        {
            if (Ravioli == null)
                Ravioli = new List<Ravioli>();

            for (int i = 0; i < numberOfRavioli; i++)
            {
                Ravioli.Add(new Ravioli(dateString));
            }
        }
    }
}
