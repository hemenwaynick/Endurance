using System;
using System.Collections.Generic;

namespace Endurance
{
    public class PathComputer
    {
        public Stack<(int, int)> ComputePath(List<List<int>> maze)
        {
            var path = new Stack<(int, int)>();
            var visitedPositions = new List<(int, int)>();

            for (var i = 0; i < maze.Count; ++i)
            {
                if (maze[i][0] == 1)
                {
                    path.Push((i, 0));
                    visitedPositions.Add((i, 0));
                    break;
                }
                if (i == maze.Count - 1)
                {
                    throw new Exception("Invalid input: first line of file is missing 'entrance'.");
                }
            }

            return ComputeRemainingPath(maze, path, visitedPositions);
        }

        private Stack<(int, int)> ComputeRemainingPath(
            List<List<int>> maze,
            Stack<(int, int)> path,
            List<(int, int)> visitedPositions)
        {
            if (path.Peek().Item2 == maze[0].Count - 1)
            {
                return path;
            }

            var x = path.Peek().Item1;
            var y = path.Peek().Item2;

            if (maze[x][y + 1] == 1 &&
                !visitedPositions.Contains((x, y + 1)))
            {
                path.Push((x, y + 1));
                visitedPositions.Add((x, y + 1));
            }
            else if (x > 0 &&
                maze[x - 1][y] == 1 &&
                !visitedPositions.Contains((x - 1, y)))
            {
                path.Push((x - 1, y));
                visitedPositions.Add((x - 1, y));
            }
            else if (x < maze.Count - 1 &&
                maze[x + 1][y] == 1 &&
                !visitedPositions.Contains((x + 1, y)))
            {
                path.Push((x + 1, y));
                visitedPositions.Add((x + 1, y));
            }
            else if (y > 0 &&
                maze[x][y - 1] == 1 &&
                !visitedPositions.Contains((x, y - 1)))
            {
                path.Push((x, y - 1));
                visitedPositions.Add((x, y - 1));
            }
            else
            {
                path.Pop();
            }

            return ComputeRemainingPath(maze, path, visitedPositions);
        }
    }
}
