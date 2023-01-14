using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;
using Xiangqi.Game;

namespace PiecesTests.ChariotTest
{
    [TestClass]
    public class Chariot_PieceMove
    {
        [TestMethod]
        public void HorizontalMove()
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
            Assert.IsTrue(move.IsValid(board), "Expected: Chariot Horizontal Move to be Valid");
        }

        [TestMethod]
        public void VerticalMove()
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
            Assert.IsTrue(move.IsValid(board), "Expected: Chariot Vertical Move to be Valid");
        }

        [TestMethod]
        public void DiagonalMove_Invalid()
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
            Assert.IsFalse(move.IsValid(board), "Expected: Chariot Diagonal Move to be Invalid");
        }

        [TestMethod]
        public void HorizontalMove_WithBlocking_Invalid()
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
            Assert.IsFalse(move.IsValid(board), "Expected: Chariot Horizontal Move Through Blocking to be Invalid");
        }

        [TestMethod]
        public void VerticalMove_WithBlocking_Invalid()
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
            Assert.IsFalse(move.IsValid(board), "Expected: Chariot Vertical Move Through Blocking to be Invalid");
        }

        [TestMethod]
        public void NoMove()
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
        public void Invalid_OldPosition()
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
        public void Invalid_NewPosition()
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
        public void Invalid_OldAndNewPosition()
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
        public void Invalid_WrongPiecePositions()
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
