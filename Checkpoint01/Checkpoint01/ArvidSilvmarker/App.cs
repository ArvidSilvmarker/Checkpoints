using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkpoint01.ArvidSilvmarker
{
    public class App
    {
        public void Run()
        {
            List<Triangle> triangles = GetUserInput();
            foreach (Triangle triangle in triangles)
                triangle.Draw();
        }

        private List<Triangle> GetUserInput()
        {
            string[] inputArray;

            while (true)
            {
                Console.Write("Ange kommando (Ex: A3-B4-A5): ");

                Console.ForegroundColor = ConsoleColor.Green;
                inputArray = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);
                Console.ResetColor();

                if (!ValidateInput(inputArray))
                    continue;
                break;
            }

            return CreateTriangles(inputArray);
        }

        private bool ValidateInput(string[] inputArray)
        {                                
            if (inputArray == null || inputArray.Length == 0)                                       
            {
                WriteText("Kommando får inte vara null eller tom.", ConsoleColor.Red);
                return false;
            }

            foreach (string input in inputArray)
            {
                if (input == null || input.Length == 0)
                {
                    WriteText("Triangel får inte vara null eller tom.", ConsoleColor.Red);
                    return false;
                }
                else if (input[0] != 'A' && input[0] != 'B')
                {
                    WriteText("Första tecknet måste vara A eller B.", ConsoleColor.Red);
                    return false;
                }
                else if (!input.Substring(1).All(Char.IsDigit))
                {
                    WriteText("Tecken efter första måste vara siffror.", ConsoleColor.Red);
                    return false;
                }
            }
            return true;
        }

        private List<Triangle> CreateTriangles(string[] inputArray)
        {
            List<Triangle> triangles = new List<Triangle>();

            foreach (string input in inputArray)
            {
                bool pointUp;
                if (input[0] == 'A')
                    pointUp = true;
                else
                    pointUp = false;

                int height = Convert.ToInt32(input.Substring(1));

                triangles.Add(new Triangle(height, pointUp));
            }

            return triangles;
        }

        private void WriteText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }

    public class Triangle
    {
        public int Height { get; private set; } //The height of the triangle.
        public bool PointUp { get; private set; } //True for point-up triangles. False for point-down triangles.

        public Triangle(int height, bool pointUp)
        {
            Height = height;
            PointUp = pointUp;
        }

        public void Draw()
        {
            if (PointUp)
                DrawPointUp();
            else
                DrawPointDown();
        }

        private void DrawPointUp()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j <= i; j++)
                    Console.Write("*");
                Console.WriteLine();
            }

        }

        private void DrawPointDown()
        {
            for (int i = Height-1; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                    Console.Write("*");
                Console.WriteLine();
            }

        }
    }
}
