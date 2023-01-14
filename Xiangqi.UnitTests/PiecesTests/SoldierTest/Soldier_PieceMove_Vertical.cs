using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;

namespace PiecesTests.SoldierTest
{
    [TestClass]
    public class Soldier_PieceMove_Vertical
    {
        [TestMethod]
        public void ForwardMove_Black()
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
        public void ForwardMove_Red()
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
        public void BackwardMove_Black_Invalid()
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
        public void BackwardMove_Red_Invalid()
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
        public void ForwardMove_AcrossMultipleSquares_Black()
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
        public void ForwardMove_AcrossMultipleSquares_Red()
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
