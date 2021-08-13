using System;
using System.Collections.Generic;

namespace Endurance
{
    public class PathComputer
    {
        public Stack<(int, int)> ComputePath(List<List<(int, bool)>> maze)
        {
            var path = new Stack<(int, int)>();

            for (var i = 0; i < maze.Count; ++i)
            {
                if (maze[i][0] == (1, false))
                {
                    path.Push((i, 0));
                    maze[i][0] = (1, true);
                    break;
                }
                if (i == maze.Count - 1)
                {
                    throw new Exception("Invalid input: first line of file is missing 'entrance'.");
                }
            }

            return ComputeRemainingPath(maze, path);
        }

        private Stack<(int, int)> ComputeRemainingPath(
            List<List<(int, bool)>> maze,
            Stack<(int, int)> path)
        {
            if (path.Peek().Item2 == maze[0].Count - 1)
            {
                return path;
            }

            var x = path.Peek().Item1;
            var y = path.Peek().Item2;

            if (maze[x][y + 1] == (1, false))
            {
                path.Push((x, y + 1));
                maze[x][y + 1] = (1, true);
            }
            else if (x > 0 && maze[x - 1][y] == (1, false))
            {
                path.Push((x - 1, y));
                maze[x - 1][y] = (1, true);
            }
            else if (x < maze.Count - 1 && maze[x + 1][y] == (1, false))
            {
                path.Push((x + 1, y));
                maze[x + 1][y] = (1, true);
            }
            else if (y > 0 && maze[x][y - 1] == (1, false))
            {
                path.Push((x, y - 1));
                maze[x][y - 1] = (1, false);
            }
            else
            {
                path.Pop();
            }

            return ComputeRemainingPath(maze, path);
        }
    }
}
