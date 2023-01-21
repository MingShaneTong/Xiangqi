using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game;
using Xiangqi.Game.Moves;

namespace Xiangqi.UnitTests.GameTests
{
    [TestClass]
    public class WinConditions
    {
        [TestMethod]
        public void Checkmate()
        {
            string boardString =
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
            Board board = BoardCreator.BuildBoard(boardString);

            Assert.IsTrue(board.IsInCheckmate(Color.Black), "Expected: Checkmate");
        }

        [TestMethod]
        public void MoveToCheckmate()
        {
            string boardString =
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
            Board board = BoardCreator.BuildBoard(boardString);
            ChessGame game = new ChessGame() { Board = board };
            Assert.IsFalse(board.IsInCheckmate(Color.Black), "Expected: Non Checkmate");
            game.PerformTurn("e6g7");
            Assert.IsTrue(board.IsInCheckmate(Color.Black), "Expected: Checkmate");
        }

        [TestMethod]
        public void Stalemate()
        {
            string boardString =
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
            Board board = BoardCreator.BuildBoard(boardString);
            Assert.IsTrue(board.IsInStalemate(Color.Black), "Expected: Stalemate");
        }
    }
}
