using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Checkpoint04
{
    class Program
    {
        private static string conString = "Server = (localdb)\\mssqllocaldb; Database = GnomeDb; Trusted_Connection = True;";

        static void Main(string[] args)

        {
            List<Gnome> x = GetGnomesFromDatabase();
            DisplayGnomes(x);
        }

        private static void DisplayGnomes(List<Gnome> gnomes)
        {
            Console.WriteLine($"{"NAMN",-24}{"HAR SKÄGG",-12}{"ÄR OND",-12}{"TEMPERAMENT",-16}");
            foreach (Gnome gnome in gnomes)
            {
                Console.WriteLine($"{gnome.Name,-24}{(gnome.HasBeard ? "Ja" : "Nej"),-12}{(gnome.IsEvil ? "Ja" : "Nej"),-12}{gnome.Temperament,-16}");
            }
        }

        private static List<Gnome> GetGnomesFromDatabase()
        {
            string sql =
                @"SELECT Name, IsEvil, HasBeard, Temperament
                  FROM Gnome";

            List<Gnome> gnomes = new List<Gnome>();

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    if (!reader.IsDBNull(0) && !reader.IsDBNull(1) && !reader.IsDBNull(2) && !reader.IsDBNull(3))
                    {
                        gnomes.Add(new Gnome
                        {
                            Name = reader.GetString(0),
                            IsEvil = reader.GetBoolean(1),
                            HasBeard = reader.GetBoolean(2),
                            Temperament = reader.GetByte(3)
                        });
                    }
                }
            }

            return gnomes;

        }
    }

    public class Gnome
    {
        public string Name { get; set; }
        public bool IsEvil { get; set; }
        public bool HasBeard { get; set; }
        public byte Temperament { get; set; }
    }


}
