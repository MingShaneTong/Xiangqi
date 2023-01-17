using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;
using Xiangqi.Game;
using Xiangqi.UnitTests.PiecesTests;

namespace PiecesTests
{
    [TestClass]
    public class CaptureMove_Tests : CaptureMoveTestClass<Chariot>
    {
        [TestMethod]
        public void ValidCapture()
        {
            Assert.IsTrue(
                MoveIsValid("Black", 3, 4, 4, 4, "Red", 4, 4),
                "Expected: Capture Move to be Valid"
            );
        }
        
        [TestMethod]
        public void NoMove()
        {
            Assert.IsFalse(
                MoveIsValid("Black", 0, 0, 0, 0, "Red", 4, 4), 
                "Expected: Capture Move with No Movement to be Invalid"
            );
        }

        [TestMethod]
        [DataRow("Black", -1, 0, 1, 0)]
        [DataRow("Black", 0, 0, -1, 0)]
        [DataRow("Black", -1, 0, -1, -1)]
        public void Invalid_Positions(string color, int oldRow, int oldCol, int newRow, int newCol)
        {

            Piece chariot = Chariot.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), chariot }
            });

            IMove move = new CaptureMove()
            {
                Color = Color.Black,
                OldPosition = new Position(oldRow, oldCol),
                NewPosition = new Position(newRow, newCol),
                Piece = chariot,
                PieceCaptured = Pawn.Of(Color.Red)
            };
            Assert.IsFalse(
                move.IsValid(board),
                "Expected: Piece Move with Invalid Positions to be Invalid"
            );
        }

        [TestMethod]
        public void Invalid_WrongPieceInOldPosition()
        {
            Piece captured = Pawn.Of(Color.Red);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), Chariot.Of(Color.Black) },
                { new Position(1, 0), captured }
            });

            IMove move = new CaptureMove()
            {
                Color = Color.Black,
                OldPosition = new Position(0, 0),
                NewPosition = new Position(1, 0),
                Piece = Pawn.Of(Color.Black),
                PieceCaptured = captured
            };
            Assert.IsFalse(
                move.IsValid(board), 
                "Expected: Piece Move with Wrong Piece in Old Position to be Invalid"
            );
        }

        [TestMethod]
        public void Invalid_WrongPieceInNewPosition()
        {
            Piece piece = Chariot.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), piece },
                { new Position(1, 0), Pawn.Of(Color.Red) }
            });

            IMove move = new CaptureMove()
            {
                Color = Color.Black,
                OldPosition = new Position(0, 0),
                NewPosition = new Position(1, 0),
                Piece = piece,
                PieceCaptured = Cannon.Of(Color.Red)
            };
            Assert.IsFalse(
                move.IsValid(board),
                "Expected: Piece Move with Wrong Piece in New Position to be Invalid"
            );
        }


        [TestMethod]
        public void Invalid_WrongDeclaredColor()
        {
            Piece piece = Chariot.Of(Color.Black);
            Piece pieceCaptured = Pawn.Of(Color.Red);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), piece },
                { new Position(1, 0), pieceCaptured }
            });

            IMove move = new CaptureMove()
            {
                Color = Color.Red,
                OldPosition = new Position(0, 0),
                NewPosition = new Position(1, 0),
                Piece = piece,
                PieceCaptured = pieceCaptured
            };
            Assert.IsFalse(
                move.IsValid(board),
                "Expected: Piece Move with Wrong Declared Color to be Invalid"
            );
        }

        [TestMethod]
        public void Invalid_SameColor()
        {
            Assert.IsFalse(
                MoveIsValid("Black", 3, 4, 4, 4, "Black", 4, 4),
                "Expected: Capture Move capturing same color to be Invalid"
            );
        }
    }
}
