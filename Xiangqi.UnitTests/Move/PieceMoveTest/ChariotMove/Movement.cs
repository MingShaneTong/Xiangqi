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
    public class Movement
    {
        [TestMethod]
        public void ValidHorizontal()
        {
            IPiece chariot = Chariot.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), chariot }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, 0),
                NewPosition = new Position(0, 8),
                Piece = chariot
            };
            Assert.IsTrue(move.IsValid(board), "Chariot Horizontal Not Valid");
        }

        [TestMethod]
        public void ValidVertical()
        {
            IPiece chariot = Chariot.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), chariot }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, 0),
                NewPosition = new Position(9, 0),
                Piece = chariot
            };
            Assert.IsTrue(move.IsValid(board), "Chariot Vertical Not Valid");
        }



        [TestMethod]
        public void InvalidNotVerticalOrHorizontal()
        {
            IPiece chariot = Chariot.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), chariot }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, 0),
                NewPosition = new Position(1, 1),
                Piece = chariot
            };
            Assert.IsFalse(move.IsValid(board), "Chariot Vertical or Horizontal Valid");
        }

        [TestMethod]
        public void InvalidHorizontalBlocking()
        {
            IPiece chariot = Chariot.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), chariot },
                { new Position(0, 1), Soldier.Of(Color.Black) }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, 0),
                NewPosition = new Position(0, 8),
                Piece = chariot
            };
            Assert.IsFalse(move.IsValid(board), "Chariot Horizontal Blocking Valid");
        }

        [TestMethod]
        public void InvalidVerticalBlocking()
        {
            IPiece chariot = Chariot.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), chariot },
                { new Position(1, 0), Soldier.Of(Color.Black) }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, 0),
                NewPosition = new Position(9, 0),
                Piece = chariot
            };
            Assert.IsFalse(move.IsValid(board), "Chariot Vertical Blocking Valid");
        }
    }
}
