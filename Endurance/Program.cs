using System;
using System.IO;
using System.Threading.Tasks;

namespace Endurance
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        private static async Task MainAsync(string[] args)
        {
            foreach (var filePath in args)
            {
                Console.WriteLine("Solution for maze in: " + filePath);
                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    await new MazeSolver(new MazeReader(), new PathComputer(), new PathWriter())
                        .SolveMaze(streamReader);
                }
                Console.WriteLine();
            }
        }
    }
}
