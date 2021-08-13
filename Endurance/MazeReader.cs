using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Endurance
{
    public class MazeReader
    {
        public async Task<List<List<int>>> BuildMazeModel(StreamReader stream)
        {
            var maze = new List<List<int>>();

            var firstLineRead = false;
            var line = await stream.ReadLineAsync();
            while (line != null)
            {
                for (var i = 0; i < line.Length; ++i)
                {
                    if (!firstLineRead)
                    {
                        maze.Add(new List<int>());
                    }
                    var @char = line[i];
                    if (@char == '0')
                    {
                        maze[i].Add(0);
                    }
                    else if (@char == '1')
                    {
                        maze[i].Add(1);
                    }
                    else
                    {
                        throw new Exception("Invalid input: file contains invalid character.");
                    }
                }

                if (!firstLineRead)
                {
                    firstLineRead = true;
                }

                line = await stream.ReadLineAsync();
            }

            return maze;
        }
    }
}
