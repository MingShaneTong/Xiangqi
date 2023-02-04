using Xiangqi.Game;
using Xiangqi.Game.Notation;

namespace Xiangqi.UnitTests.GameTests
{
    [TestClass]
    public class WinConditions
    {
        [TestMethod]
        public void Checkmate()
        {
            var boardString =
                " | | | | |k| | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | |R| | | \n" +
                " | | | | | | | | \n" +
                " | | |r| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | |K| | | | ";
            var board = BoardCreator.BuildBoard(boardString);

            Assert.IsTrue(board.IsInCheckmate(Color.Black), "Expected: Checkmate");
        }

        [TestMethod]
        public void MoveToCheckmate()
        {
            var boardString =
                " | | | | |k| | | \n" +
                " | | | |P| | | | \n" +
                " | | | | | | | | \n" +
                " | | | |H| | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | |r| | | | \n" +
                " | | |K| | | | | ";
            var board = BoardCreator.BuildBoard(boardString);

            var notation = new BasicAlgebraicNotation();
            var game = new ChessGame(notation) { Board = board };
            Assert.IsFalse(board.IsInCheckmate(Color.Black), "Expected: Non Checkmate");
            game.PerformTurn("e6g7");
            Assert.IsTrue(board.IsInCheckmate(Color.Black), "Expected: Checkmate");
        }

        [TestMethod]
        public void Stalemate()
        {
            var boardString =
                " | | |k|r|a| | | \n" +
                " | | |h|c|H| | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | |K| | | | | ";
            var board = BoardCreator.BuildBoard(boardString);
            Assert.IsTrue(board.IsInStalemate(Color.Black), "Expected: Stalemate");
        }
    }
}
