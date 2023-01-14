using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;
using Xiangqi.Game;
using System.Runtime.InteropServices;

namespace MovesTests.PieceMoveTest
{
    [TestClass]
    public class PieceMoveTests
    {

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
            Assert.IsFalse(moveBlack.IsValid(board), "Expected: Piece Move with No Movement to be Invalid");
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
            Assert.IsFalse(move.IsValid(board), "Expected: Piece Move with Invalid Old Position to be Invalid");
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
            Assert.IsFalse(move.IsValid(board), "Expected: Piece Move with Invalid New Position to be Invalid");
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
            Assert.IsFalse(move.IsValid(board), "Expected: Piece Move with Invalid Old And New Position to be Invalid");
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
        public void PieceMove_InNewPosition()
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
