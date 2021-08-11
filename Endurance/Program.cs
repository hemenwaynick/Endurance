using System;
using System.IO;

namespace Endurance
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var filePath in args)
            {
                Console.WriteLine("Solution for maze in: " + filePath);
                new MazeSolver().SolveMaze(new StreamReader(filePath));
                Console.WriteLine();
            }
        }
    }
}
