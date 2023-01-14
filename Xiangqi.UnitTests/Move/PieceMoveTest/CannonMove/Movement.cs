using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;
using Xiangqi.Game;

namespace Xiangqi.UnitTests.Move.PieceMoveTest.CannonMove
{
    [TestClass]
    public class Movement
    {
        [TestMethod]
        public void ValidHorizontal()
        {
            IPiece cannon = Cannon.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), cannon }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, 0),
                NewPosition = new Position(0, 8),
                Piece = cannon
            };
            Assert.IsTrue(move.IsValid(board), "Cannon Horizontal Not Valid");
        }

        [TestMethod]
        public void ValidVertical()
        {
            IPiece cannon = Cannon.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), cannon }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, 0),
                NewPosition = new Position(9, 0),
                Piece = cannon
            };
            Assert.IsTrue(move.IsValid(board), "Cannon Vertical Not Valid");
        }

        [TestMethod]
        public void InvalidNotVerticalOrHorizontal()
        {
            IPiece cannon = Cannon.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), cannon }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, 0),
                NewPosition = new Position(1, 1),
                Piece = cannon
            };
            Assert.IsFalse(move.IsValid(board), "Cannon Vertical or Horizontal Valid");
        }

        [TestMethod]
        public void InvalidHorizontalBlocking()
        {
            IPiece cannon = Cannon.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), cannon },
                { new Position(0, 1), Soldier.Of(Color.Black) }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, 0),
                NewPosition = new Position(0, 8),
                Piece = cannon
            };
            Assert.IsFalse(move.IsValid(board), "Cannon Horizontal Blocking Valid");
        }

        [TestMethod]
        public void InvalidVerticalBlocking()
        {
            IPiece cannon = Cannon.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), cannon },
                { new Position(1, 0), Soldier.Of(Color.Black) }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, 0),
                NewPosition = new Position(9, 0),
                Piece = cannon
            };
            Assert.IsFalse(move.IsValid(board), "Cannon Vertical Blocking Valid");
        }
    }
}
