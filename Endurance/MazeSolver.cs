using System;
using System.Collections.Generic;
using System.IO;

namespace Endurance
{
    public class MazeSolver
    {
        public void SolveMaze(StreamReader stream)
        {
            var mazeModel = BuildMazeModel(stream);
            var path = ComputePath(mazeModel);
            PrintStepsInOrder(path);
        }

        private List<List<int>> BuildMazeModel(StreamReader stream)
        {
            var maze = new List<List<int>>();

            var firstLineRead = false;
            var line = stream.ReadLine();
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

                line = stream.ReadLine();
            }

            return maze;
        }

        private Stack<(int, int)> ComputePath(List<List<int>> maze)
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

        private void PrintStepsInOrder(Stack<(int, int)> path)
        {
            var reversedPath = new Stack<(int, int)>();
            while (path.Count > 0)
            {
                reversedPath.Push(path.Pop());
            }

            while (reversedPath.Count > 0)
            {
                var position = reversedPath.Pop();
                Console.WriteLine($"({position.Item1},{position.Item2})");
            }
        }
    }
}
