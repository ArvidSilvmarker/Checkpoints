using System;
using System.Collections.Generic;
using Space.Domain;

namespace Space.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var handler = new SpaceHandler();
            var writer = new SpaceWriter();

            handler.RecreateDatabase();

            handler.AddSpaceship("USS Enterprise");
            handler.AddSpaceship("Millennium Falcon");
            handler.AddSpaceship("Cylon Raider");

            handler.AddRavioliForSpaceship("Cylon Raider", 1, "2018-04-19");
            handler.AddRavioliForSpaceship("Millennium Falcon", 1, "2017-01-01");
            handler.AddRavioliForSpaceship("Millennium Falcon", 2, "2018-01-01");
            handler.AddRavioliForSpaceship("Nalle Puh", 99, "1950-01-01");

            List<Spaceship> list = handler.GetAllSpaceships();
            writer.DisplaySpaceships(list);
        }
    }
}
