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
    public class PieceMove_Tests : PieceMoveTestClass<Soldier>
    {
        [TestMethod]
        public void NoMove()
        {
            Assert.IsFalse(
                MoveIsValid("Black", 0, 0, 0, 0), 
                "Expected: Piece Move with No Movement to be Invalid"
            );
        }

        [TestMethod]
        [DataRow("Black", -1, -1, 0, 0)]
        [DataRow("Black", 0, 0, -1,-1)]
        [DataRow("Black", -1, -1, -1, -1)]
        public void Invalid_Positions(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            IPiece chariot = Chariot.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), chariot }
            });

            IMove move = new PieceMove()
            {
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
        public void Invalid_NoPieceInOldPositions()
        {
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>());

            IMove move = new PieceMove()
            {
                OldPosition = new Position(3, 6),
                NewPosition = new Position(3, 7),
                Piece = Chariot.Of(Color.Black)
            };
            Assert.IsFalse(move.IsValid(board), "Expected: Piece Move with Wrong Piece in Old Position to be Invalid");
        }

        [TestMethod]
        public void Invalid_WrongPieceInOldPositions()
        {
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), Soldier.Of(Color.Black) }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(3, 6),
                NewPosition = new Position(3, 7),
                Piece = Chariot.Of(Color.Black)
            };
            Assert.IsFalse(move.IsValid(board), "Expected: Piece Move with Wrong Piece in Old Position to be Invalid");
        }

        [TestMethod]
        public void PieceMove_PieceAlreadyInNewPosition()
        {
            IPiece chariot = Chariot.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(0, 0), chariot },
                { new Position(0, 1), Soldier.Of(Color.Red) }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(0, 0),
                NewPosition = new Position(0, 1),
                Piece = chariot
            };
            Assert.IsFalse(move.IsValid(board), "Expected: Piece Move with Piece already in New Position to be Invalid");
        }
    }
}
