using System;
using System.Collections.Generic;

namespace Endurance
{
    public class PathWriter
    {
        public void PrintStepsInOrder(Stack<(int, int)> path)
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
