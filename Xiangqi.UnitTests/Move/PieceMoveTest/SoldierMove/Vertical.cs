using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;

namespace Xiangqi.UnitTests.Move.PieceMoveTest.SoldierMove
{
    [TestClass]
    public class Vertical
    {
        [TestMethod]
        public void ValidForwardBlack()
        {
            IPiece soldier = Soldier.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(3, 6), soldier }
            });

            IMove moveBlack = new PieceMove()
            {
                OldPosition = new Position(3, 6),
                NewPosition = new Position(4, 6),
                Piece = soldier
            };
            Assert.IsTrue(moveBlack.IsValid(board), "Expected: Black Soldier Forward Move to be Valid");
        }

        [TestMethod]
        public void ValidForwardRed()
        {
            IPiece soldier = Soldier.Of(Color.Red);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(6, 2), soldier }
            });

            IMove moveRed = new PieceMove()
            {
                OldPosition = new Position(6, 2),
                NewPosition = new Position(5, 2),
                Piece = soldier
            };
            Assert.IsTrue(moveRed.IsValid(board), "Expected: Red Soldier Forward Move to be Valid");
        }

        [TestMethod]
        public void InvalidBackwardBlack()
        {
            IPiece soldier = Soldier.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(3, 6), soldier }
            });

            IMove moveBlack = new PieceMove()
            {
                OldPosition = new Position(3, 6),
                NewPosition = new Position(2, 6),
                Piece = soldier
            };
            Assert.IsFalse(moveBlack.IsValid(board), "Expected: Black Soldier Backward Move to be Invalid");
        }

        [TestMethod]
        public void InvalidBackwardRed()
        {
            IPiece soldier = Soldier.Of(Color.Red);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(6, 2), soldier }
            });

            IMove moveRed = new PieceMove()
            {
                OldPosition = new Position(6, 2),
                NewPosition = new Position(7, 2),
                Piece = soldier
            };
            Assert.IsFalse(moveRed.IsValid(board), "Expected: Red Soldier Backward Move to be Invalid");
        }

        [TestMethod]
        public void InvalidMultiForwardBlack()
        {
            IPiece soldier = Soldier.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(3, 6), soldier }
            });

            IMove moveBlack = new PieceMove()
            {
                OldPosition = new Position(3, 6),
                NewPosition = new Position(5, 6),
                Piece = soldier
            };
            Assert.IsFalse(moveBlack.IsValid(board), "Expected: Black Soldier Forward across multiple squares to be Invalid");
        }

        [TestMethod]
        public void InvalidMultiForwardRed()
        {
            IPiece soldier = Soldier.Of(Color.Red);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(6, 2), soldier }
            });

            IMove moveRed = new PieceMove()
            {
                OldPosition = new Position(6, 2),
                NewPosition = new Position(4, 2),
                Piece = soldier
            };
            Assert.IsFalse(moveRed.IsValid(board), "Expected: Red Soldier Forward across multiple squares to be Invalid");
        }
    }
}
