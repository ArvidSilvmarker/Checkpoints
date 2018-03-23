using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Checkpoint02.ArvidSilvmarker
{
    class App
    {
        public void Run()
        {
            try
            {
                while (true)
                {
                    List<List<string>> userInput = UserInput("Ange rum i lägenheten: ");
                    List<Room> listOfRooms = GenerateRooms(userInput);
                    RoomReport(listOfRooms);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private void RoomReport(List<Room> listOfRooms)
        {
            List<Room> roomsWithLightsOn = new List<Room>();
            Room largest = listOfRooms[0];
            foreach (Room room in listOfRooms)
            {
                if (room.LightsOn)
                    roomsWithLightsOn.Add(room);
                if (room.Area > largest.Area)
                    largest = room;
            }

            string lightText;
            if (roomsWithLightsOn.Count == 0)
                lightText = $"Inget rum är tänt.";
            else
            {
                lightText = "Ljuset är tänt i ";
                for (int i = 0; i < roomsWithLightsOn.Count; i++)
                {

                    if (i < roomsWithLightsOn.Count - 1)
                        lightText = $"{lightText}{roomsWithLightsOn[i].Name} och ";
                    else
                        lightText = $"{lightText}{roomsWithLightsOn[i].Name}.";
                }
            }
            WriteText(lightText, ConsoleColor.Green);

            WriteText($"Det största rummet är {largest.Name} på {largest.Area}m2.", ConsoleColor.Green);
            WriteText($"Lägenheten består av {listOfRooms.Count} rum.", ConsoleColor.Green);


        }

        private List<Room> GenerateRooms(List<List<string>> userInput)
        {
            List<Room> listOfRooms = new List<Room>();
            foreach (List<string> room in userInput)
                listOfRooms.Add(new Room(room[0], Convert.ToInt32(room[1].Remove(room[1].Length - 2)),
                    room[2] == "On" ? true : false));
            return listOfRooms;
        }

        private List<List<string>> UserInput(string questionToUser)
        {
            bool invalidInput = false;
            List<List<string>> listOfRoomLists = new List<List<string>>();
            while (true)
            {

                if (invalidInput)
                {
                    Console.WriteLine();
                    WriteText("Ogiltigt indata.", ConsoleColor.Red);
                }

                Console.WriteLine();
                WriteText(questionToUser, ConsoleColor.White);

                try
                {
                    listOfRoomLists = ReadRoomsFromUser();
                }
                catch (ArgumentException e)
                {
                    invalidInput = true;
                    continue;
                }

                break;
            }

            Console.WriteLine("------------------------------------------------------");
            return listOfRoomLists;



        }

        private List<List<string>> ReadRoomsFromUser()
        {
            string userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
                throw new ArgumentException("Måste skriva text. ");


            List<string> listOfRoomStrings = userInput.Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();

            if (!ValidListOfRoomStrings(listOfRoomStrings))
                throw new ArgumentException("Fel format på rummen.");

            List<List<string>> listOfRoomLists = new List<List<string>>();
            foreach (string roomString in listOfRoomStrings)
                listOfRoomLists.Add(roomString.Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList());

            if (!ValidListOFRoomLists(listOfRoomLists))
                throw new ArgumentException("Fel format på rummens parametrar.");

            return listOfRoomLists;
        }

        private bool ValidListOFRoomLists(List<List<string>> listOfRoomLists)
        {
            foreach (List<string> listOfRoomStrings in listOfRoomLists)
            {
                
                try
                {
                    if (listOfRoomStrings.Count != 3)
                        return false;

                    if (!ValidName(listOfRoomStrings[0]))
                        return false;

                    if (!ValidArea(listOfRoomStrings[1]))
                        return false;

                    if (!ValidLights(listOfRoomStrings[2]))
                        return false;
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Något var fel med rummets parametrar.");
                }
            }
            return true;
        }

        private bool ValidLights(string lights)
        {
            if (string.IsNullOrWhiteSpace(lights))
                return false;

            return new Regex(@"^On|Off$").IsMatch(lights);
        }

        private bool ValidArea(string area)
        {
            if (string.IsNullOrWhiteSpace(area))
                return false;

            if (!new Regex(@"^\d+m2$").IsMatch(area))
                return false;
            else if (Convert.ToInt32(area.Remove(area.Length - 2)) <= 0)
                return false;
            return true;

        }

        private bool ValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            return new Regex(@"^[a-zåäöA-ZÅÄÖ-]+$").IsMatch(name);
        }

        private bool ValidListOfRoomStrings(List<string> listOfRoomStrings)
        {
            foreach (string room in listOfRoomStrings)
                if (string.IsNullOrWhiteSpace(room))
                    return false;
            return true;
        }

        private void WriteText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
