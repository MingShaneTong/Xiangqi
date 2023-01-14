using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;
using Xiangqi.Game;

namespace Xiangqi.UnitTests.Move.PieceMoveTest.ChariotMove
{
    [TestClass]
    public class PreCondition
    {
        [TestMethod]
        public void InvalidNoMove()
        {
            IPiece chariot = Chariot.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), chariot }
            });

            IMove moveBlack = new PieceMove()
            {
                OldPosition = new Position(0, 0),
                NewPosition = new Position(0, 0),
                Piece = chariot
            };
            Assert.IsFalse(moveBlack.IsValid(board), "Expected: Chariot No Move to be Invalid");
        }

        [TestMethod]
        public void InvalidOldPosition()
        {
            IPiece chariot = Chariot.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), chariot }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, -1),
                NewPosition = new Position(0, 0),
                Piece = chariot
            };
            Assert.IsFalse(move.IsValid(board), "Expected: Chariot Move with Invalid Old Position to be Invalid");
        }


        [TestMethod]
        public void InvalidNewPosition()
        {
            IPiece chariot = Chariot.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), chariot }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, 0),
                NewPosition = new Position(0, -1),
                Piece = chariot
            };
            Assert.IsFalse(move.IsValid(board), "Expected: Chariot Move with Invalid New Position to be Invalid");
        }

        [TestMethod]
        public void InvalidOldAndNewPosition()
        {
            IPiece chariot = Chariot.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), chariot }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, -1),
                NewPosition = new Position(0, -2),
                Piece = chariot
            };
            Assert.IsFalse(move.IsValid(board), "Expected: Chariot Move with Invalid Old And New Position to be Invalid");
        }

        [TestMethod]
        public void InvalidWrongPiecePositions()
        {
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>());

            IMove move = new PieceMove()
            {
                OldPosition = new Position(3, 6),
                NewPosition = new Position(3, 7),
                Piece = Chariot.Of(Color.Black)
            };
            Assert.IsFalse(move.IsValid(board), "Expected: Chariot Move with Wrong Piece to be Invalid");
        }
    }
}
