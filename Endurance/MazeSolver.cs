using System.IO;
using System.Threading.Tasks;

namespace Endurance
{
    public class MazeSolver
    {
        private readonly MazeReader _mazeReader;
        private readonly PathComputer _pathComputer;
        private readonly PathWriter _pathWriter;

        public MazeSolver(
            MazeReader mazeReader,
            PathComputer pathComputer,
            PathWriter pathWriter)
        {
            _mazeReader = mazeReader;
            _pathComputer = pathComputer;
            _pathWriter = pathWriter;
        }

        public async Task SolveMaze(StreamReader streamReader)
        {
            var maze = await _mazeReader.BuildMazeModel(streamReader);
            var path = _pathComputer.ComputePath(maze);
            _pathWriter.PrintStepsInOrder(path);
        }
    }
}
