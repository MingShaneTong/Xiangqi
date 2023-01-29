using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;
using Xiangqi.Game;
using Xiangqi.UnitTests;

namespace PiecesTests
{
    [TestClass]
    public class Move_Tests
    {
        [TestMethod]
        public void NoMove()
        {
            string board =
                "r|h|e|a|k|a|e|h|r\n" +
                " | | | | | | | | \n" +
                " |c| | | | | |c| \n" +
                "p| |p| |p| |p| |p\n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                "P| |P| |P| |P| |P\n" +
                " |C| | | | | |C| \n" +
                " | | | | | | | | \n" +
                "R|H|E|A|K|A|E|H|R";
            string move = "a0a0";
            bool result = TestSupport.MoveIsValid(board, Color.Black, move);
            Assert.IsFalse(result, "Expected: Piece Move with No Movement to be Invalid");
        }

        [TestMethod]
        [DataRow("Black", -1, -1, 0, 0)]
        [DataRow("Black", 0, 0, -1,-1)]
        [DataRow("Black", -1, -1, -1, -1)]
        public void Invalid_Positions(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Piece chariot = Rook.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), chariot },
                { new Position(0, 3), King.Of(Color.Black) },
                { new Position(9, 5), King.Of(Color.Red) }
            });

            IMove move = new Move()
            {
                Color = Color.Black,
                OldPosition = new Position(oldRow, oldCol),
                NewPosition = new Position(newRow, newCol),
                Piece = chariot
            };
            Assert.IsFalse(
                move.IsValid(board), 
                "Expected: Piece Move with Invalid Positions to be Invalid"
            );
        }

        [TestMethod]
        public void NoPiece_InOldPositions()
        {
            Board board = BoardCreator.BuildBoard(
                " | | |k| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | |K| | | "
            );

            IMove move = new Move()
            {
                Color = Color.Black,
                OldPosition = new Position(0, 0),
                NewPosition = new Position(1, 0),
                Piece = Rook.Of(Color.Black)
            };
            Assert.IsFalse(move.IsValid(board), "Expected: Piece Move with Wrong Piece in Old Position to be Invalid");
        }

        [TestMethod]
        public void WrongPiece_InOldPositions()
        {
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), Pawn.Of(Color.Black) },
                { new Position(0, 3), King.Of(Color.Black) },
                { new Position(9, 5), King.Of(Color.Red) }
            });

            IMove move = new Move()
            {
                Color = Color.Black,
                OldPosition = new Position(0, 0),
                NewPosition = new Position(1, 0),
                Piece = Rook.Of(Color.Black)
            };
            Assert.IsFalse(move.IsValid(board), "Expected: Piece Move with Wrong Piece in Old Position to be Invalid");
        }

        [TestMethod]
        public void CapturedPiece_NotSpecified()
        {
            Piece chariot = Rook.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), chariot },
                { new Position(0, 1), Pawn.Of(Color.Red) },
                { new Position(0, 3), King.Of(Color.Black) },
                { new Position(9, 5), King.Of(Color.Red) }
            });

            IMove move = new Move()
            {
                Color = Color.Black,
                OldPosition = new Position(0, 0),
                NewPosition = new Position(0, 1),
                Piece = chariot
            };
            Assert.IsFalse(move.IsValid(board), "Expected: Piece Move with captured piece not specified to be Invalid");
        }

        [TestMethod]
        public void Move_WrongColor()
        {
            Piece chariot = Rook.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), chariot },
                { new Position(0, 3), King.Of(Color.Black) },
                { new Position(9, 5), King.Of(Color.Red) }
            });

            IMove move = new Move()
            {
                Color = Color.Red,
                OldPosition = new Position(0, 0),
                NewPosition = new Position(0, 1),
                Piece = chariot
            };
            Assert.IsFalse(move.IsValid(board), "Expected: Piece Move with wrong Color to be Invalid");
        }

        [TestMethod]
        [DataRow(Color.Red, "b0c0")]
        [DataRow(Color.Black, "c0b0")]
        public void Move_Capture_OtherColor(Color color, string move)
        {
            string board =
                " | | | |k| | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | |K| | | \n" +
                "R|R|r|r| | | | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsTrue(result, "Expected: Capture Other Piece to be Valid");
        }

        [TestMethod]
        [DataRow(Color.Red, "b0a0")]
        [DataRow(Color.Black, "c0d0")]
        public void Move_Capture_OwnColor(Color color, string move)
        {
            string board =
                " | | | |k| | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | |K| | | \n" +
                "R|R|r|r| | | | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Capture Own Piece to be Invalid");
        }
    }
}
