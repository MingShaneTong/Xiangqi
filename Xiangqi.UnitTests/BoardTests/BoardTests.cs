using Xiangqi.Game;
using Xiangqi.Game.Pieces;

namespace Xiangqi.UnitTests.BoardTests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void GetPositionSide_Test()
        {
            for (var row = 0; row < 5; row++)
            { 
                for (var col = 0; col < Board.Cols; col++)
                {
                    Assert.IsTrue(Board.GetPositionSide(new Position(row, col)) == Color.Black);
                }
            }

            for (var row = 5; row < Board.Rows; row++)
            {
                for (var col = 0; col < Board.Cols; col++)
                {
                    Assert.IsTrue(Board.GetPositionSide(new Position(row, col)) == Color.Red);
                }
            }
        }


        [TestMethod]
        public void InCastle_Test()
        {
            var blackCastlePositions = new HashSet<Position> {
                new Position(0, 3), new Position(0, 4), new Position(0, 5),
                new Position(1, 3), new Position(1, 4), new Position(1, 5),
                new Position(2, 3), new Position(2, 4), new Position(2, 5),
            };
            var redCastlePositions = new HashSet<Position> {
                new Position(7, 3), new Position(7, 4), new Position(7, 5),
                new Position(8, 3), new Position(8, 4), new Position(8, 5),
                new Position(9, 3), new Position(9, 4), new Position(9, 5),
            };

            for (var row = 0; row < Board.Rows; row++)
            {
                for (var col = 0; col < Board.Cols; col++)
                {
                    var position = new Position(row, col);
                    Assert.AreEqual(
                        blackCastlePositions.Contains(position),
                        Board.InCastle(Color.Black, position),
                        "Error on Black Castle Identification at " + position.ToString()
                    );
                    Assert.AreEqual(
                        redCastlePositions.Contains(position),
                        Board.InCastle(Color.Red, position),
                        "Error on Red Castle Identification at " + position.ToString()
                    );
                }
            }
        }

        [TestMethod]
        public void GetDiagonalPiecesBetween_Test()
        {
            var board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(4, 5), Pawn.Of(Color.Black) },

                { new Position(2, 3), Pawn.Of(Color.Black) },

                { new Position(5, 4), Pawn.Of(Color.Black) },
                { new Position(6, 3), Pawn.Of(Color.Black) },
                { new Position(7, 2), Pawn.Of(Color.Black) },
                { new Position(8, 1), Pawn.Of(Color.Black) }
            });

            var center = new Position(4, 5);

            Assert.IsTrue(board.GetDiagonalPiecesBetween(center, new Position(9, 0)).Count() == 4);
            Assert.IsTrue(board.GetDiagonalPiecesBetween(center, new Position(0, 1)).Count() == 1);
            Assert.IsTrue(board.GetDiagonalPiecesBetween(center, new Position(1, 8)).Count() == 0);
        }
    }
}
