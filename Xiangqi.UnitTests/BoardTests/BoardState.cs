using System.Diagnostics;
using Xiangqi.Game;

namespace Xiangqi.UnitTests.BoardTests
{
    [TestClass]
    public class BoardState
    {
        [TestMethod]
        public void InitialBoardPosition()
        {
            Board board = BoardCreator.InitBoard();
            Trace.WriteLine(board);
            Assert.AreEqual(board.ToString(),
                "r|h|e|a|k|a|e|h|r\n" +
                " | | | | | | | | \n" +
                " |c| | | | | |c| \n" +
                "p| |p| |p| |p| |p\n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                "P| |P| |P| |P| |P\n" +
                " |C| | | | | |C| \n" +
                " | | | | | | | | \n" +
                "R|H|E|A|K|A|E|H|R"
            );
        }
    }
}