using System;
using System.Collections.Generic;
using Space.Domain;

namespace Space.Program
{
    public class SpaceWriter
    {
        public void DisplaySpaceships(List<Spaceship> list)
        {
            foreach (var spaceship in list)
            {
                WriteLineColor(spaceship.Name, ConsoleColor.White);
                if (spaceship.Ravioli == null || spaceship.Ravioli.Count == 0)
                {
                    WriteLineColor("Slut på ravioli. Skicka räddningsskepp!", ConsoleColor.Magenta);
                }
                else
                {
                    foreach (var ravioli in spaceship.Ravioli)
                    {
                        WriteLineColor($"Ravioli Packdatum: {ravioli.PackDate.Date:yyyy-MM-dd} Utgångsdatum: {ravioli.ExpiryDate.Date:yyyy-MM-dd}", ConsoleColor.Magenta);
                    }
                }

                Console.WriteLine();
            }
        }

        public void WriteLineColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
