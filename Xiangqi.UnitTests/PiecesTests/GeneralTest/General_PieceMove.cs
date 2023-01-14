using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;
using Xiangqi.Game;

namespace PiecesTests.GeneralTest
{
    [TestClass]
    public class General_PieceMove
    {
        [TestMethod]
        public void HorizontalMove()
        {
            IPiece general = General.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 4), general }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, 4),
                NewPosition = new Position(0, 5),
                Piece = general
            };
            Assert.IsTrue(move.IsValid(board), "Expected: General Horizontal Move to be Valid");
        }

        [TestMethod]
        public void VerticalMove()
        {
            IPiece general = General.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 4), general }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, 4),
                NewPosition = new Position(1, 4),
                Piece = general
            };
            Assert.IsTrue(move.IsValid(board), "Expected: General Vertical Move to be Valid");
        }

        [TestMethod]
        public void HorizontalMove_AcrossMultipleSquares()
        {
            IPiece general = General.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 3), general }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, 3),
                NewPosition = new Position(0, 5),
                Piece = general
            };
            Assert.IsFalse(move.IsValid(board), "Expected: General Horizontal Move Across Multiple Squares to be Invalid");
        }

        [TestMethod]
        public void VerticalMove_AcrossMultipleSquares()
        {
            IPiece general = General.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 3), general }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, 3),
                NewPosition = new Position(2, 3),
                Piece = general
            };
            Assert.IsFalse(move.IsValid(board), "Expected: General Vertical Move Across Multiple Squares to be Invalid");
        }

        [TestMethod]
        public void DiagonalMove()
        {
            IPiece general = General.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 3), general }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, 3),
                NewPosition = new Position(1, 4),
                Piece = general
            };
            Assert.IsFalse(move.IsValid(board), "Expected: General Diagonal Move to be Invalid");
        }

        [TestMethod]
        public void Move_OutOfCastle()
        {
            IPiece general = General.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 3), general }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, 3),
                NewPosition = new Position(0, 2),
                Piece = general
            };
            Assert.IsFalse(move.IsValid(board), "Expected: General Moves Out of Castle to be Invalid");
        }
    }
}
