using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;
using Xiangqi.Game;

namespace Xiangqi.UnitTests.Move.PieceMoveTest.SoldierMove
{
    [TestClass]
    public class Horizontal
    {
        [TestMethod]
        public void ValidHorizontalBlack()
        {
            IPiece soldier = Soldier.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(5, 6), soldier }
            });

            IMove moveBlack = new PieceMove()
            {
                OldPosition = new Position(5, 6),
                NewPosition = new Position(5, 5),
                Piece = soldier
            };
            Assert.IsTrue(moveBlack.IsValid(board), "Black Soldier Horizontal Not Valid");
        }

        [TestMethod]
        public void ValidHorizontalRed()
        {
            IPiece soldier = Soldier.Of(Color.Red);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(4, 2), soldier }
            });

            IMove moveRed = new PieceMove()
            {
                OldPosition = new Position(4, 2),
                NewPosition = new Position(4, 3),
                Piece = soldier
            };
            Assert.IsTrue(moveRed.IsValid(board), "Red Soldier Horizontal Not Valid");
        }

        [TestMethod]
        public void InvalidMultiHorizontalBlack()
        {
            IPiece soldier = Soldier.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(5, 6), soldier }
            });

            IMove moveBlack = new PieceMove()
            {
                OldPosition = new Position(5, 6),
                NewPosition = new Position(5, 4),
                Piece = soldier
            };
            Assert.IsFalse(moveBlack.IsValid(board), "Black Soldier Horizontal Valid");
        }

        [TestMethod]
        public void InvalidMultiHorizontalRed()
        {
            IPiece soldier = Soldier.Of(Color.Red);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(4, 2), soldier }
            });

            IMove moveRed = new PieceMove()
            {
                OldPosition = new Position(4, 2),
                NewPosition = new Position(4, 4),
                Piece = soldier
            };
            Assert.IsFalse(moveRed.IsValid(board), "Red Soldier MultiHorizontal Valid");
        }

        [TestMethod]
        public void InvalidHorizontalNotOverRiverBlack()
        {
            IPiece soldier = Soldier.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(3, 6), soldier }
            });

            IMove moveBlack = new PieceMove()
            {
                OldPosition = new Position(3, 6),
                NewPosition = new Position(3, 7),
                Piece = soldier
            };
            Assert.IsFalse(moveBlack.IsValid(board), "Black Soldier MultiHorizontal Valid");
        }

        [TestMethod]
        public void InvalidHorizontalNotOverRiverRed()
        {
            IPiece soldier = Soldier.Of(Color.Red);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(6, 2), soldier }
            });

            IMove moveRed = new PieceMove()
            {
                OldPosition = new Position(6, 2),
                NewPosition = new Position(6, 3),
                Piece = soldier
            };
            Assert.IsFalse(moveRed.IsValid(board), "Red Soldier Horizontal Not Over River Valid");
        }
    }
}
