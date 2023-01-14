using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;
using Xiangqi.Game;

namespace PiecesTests.CannonTest
{
    [TestClass]
    public class Cannon_PieceMove
    {
        [TestMethod]
        public void HorizontalMove()
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
            Assert.IsTrue(move.IsValid(board), "Expected: Cannon Horizontal Move to be Valid");
        }

        [TestMethod]
        public void VerticalMove()
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
            Assert.IsTrue(move.IsValid(board), "Expected: Cannon Vertical Move to be Valid");
        }

        [TestMethod]
        public void DiagonalMove_Invalid()
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
            Assert.IsFalse(move.IsValid(board), "Expected: Cannon Diagonal Move to be Invalid");
        }

        [TestMethod]
        public void HorizontalMove_WithBlocking_Invalid()
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
            Assert.IsFalse(move.IsValid(board), "Expected: Cannon Horizontal Move Through Blocking to be Invalid");
        }

        [TestMethod]
        public void VerticalMove_WithBlocking_Invalid()
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
            Assert.IsFalse(move.IsValid(board), "Expected: Cannon Vertical Move Through Blocking to be Invalid");
        }

        [TestMethod]
        public void NoMove()
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
            Assert.IsFalse(moveBlack.IsValid(board), "Expected: Cannon No Move to be Invalid");
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
            Assert.IsFalse(move.IsValid(board), "Expected: Cannon Move with Invalid Old Position to be Invalid");
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
            Assert.IsFalse(move.IsValid(board), "Expected: Cannon Move with Invalid New Position to be Invalid");
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
            Assert.IsFalse(move.IsValid(board), "Expected: Cannon Invalid Old And New Position to be Invalid");
        }

        [TestMethod]
        public void WrongPiece_InOldPosition()
        {
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>());

            IMove move = new PieceMove()
            {
                OldPosition = new Position(3, 6),
                NewPosition = new Position(3, 7),
                Piece = Cannon.Of(Color.Black)
            };
            Assert.IsFalse(move.IsValid(board), "Expected: Cannon Move with Wrong Piece to be Invalid");
        }
    }
}
