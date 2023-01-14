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
    public class PreCondition
    {
        [TestMethod]
        public void InvalidNoMove()
        {
            IPiece cannon = Cannon.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), cannon }
            });

            IMove moveBlack = new PieceMove()
            {
                OldPosition = new Position(0, 0),
                NewPosition = new Position(0, 0),
                Piece = cannon
            };
            Assert.IsFalse(moveBlack.IsValid(board), "Cannon No Move Valid");
        }

        [TestMethod]
        public void InvalidOldPosition()
        {
            IPiece cannon = Cannon.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), cannon }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, -1),
                NewPosition = new Position(0, 0),
                Piece = cannon
            };
            Assert.IsFalse(move.IsValid(board), "Cannon Old Position Valid");
        }


        [TestMethod]
        public void InvalidNewPosition()
        {
            IPiece cannon = Cannon.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), cannon }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, 0),
                NewPosition = new Position(0, -1),
                Piece = cannon
            };
            Assert.IsFalse(move.IsValid(board), "Cannon New Position Valid");
        }

        [TestMethod]
        public void InvalidOldAndNewPosition()
        {
            IPiece cannon = Cannon.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), cannon }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, -1),
                NewPosition = new Position(0, -2),
                Piece = cannon
            };
            Assert.IsFalse(move.IsValid(board), "Cannon Old And New Position Valid");
        }

        [TestMethod]
        public void InvalidWrongPiecePositions()
        {
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>());

            IMove move = new PieceMove()
            {
                OldPosition = new Position(3, 6),
                NewPosition = new Position(3, 7),
                Piece = Cannon.Of(Color.Black)
            };
            Assert.IsFalse(move.IsValid(board), "Wrong Piece Move Valid");
        }
    }
}
