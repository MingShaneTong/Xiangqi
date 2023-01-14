using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;
using Xiangqi.Game;

namespace PiecesTests.SoldierTest
{
    [TestClass]
    public class Soldier_PieceMove_Horizontal
    {
        [TestMethod]
        public void HorizontalMove_Black()
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
            Assert.IsTrue(moveBlack.IsValid(board), "Expected: Black Soldier Horizontal Move to be Valid");
        }

        [TestMethod]
        public void HorizontalMove_Red()
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
            Assert.IsTrue(moveRed.IsValid(board), "Expected: Red Soldier Horizontal Move to be Valid");
        }

        [TestMethod]
        public void HorizontalMove_AcrossMultipleSquares_Black()
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
            Assert.IsFalse(moveBlack.IsValid(board), "Expected: Black Soldier Horizontal Move across multiple squares to be invalid");
        }

        [TestMethod]
        public void HorizontalMove_AcrossMultipleSquares_Red()
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
            Assert.IsFalse(moveRed.IsValid(board), "Expected: Red Soldier Horizontal Move across multiple squares to be invalid");
        }

        [TestMethod]
        public void HorizontalMove_NotOverRiver_Black()
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
            Assert.IsFalse(moveBlack.IsValid(board), "Expected: Black Soldier Horizontal Move when not across the river to be invalid");
        }

        [TestMethod]
        public void HorizontalMove_NotOverRiver_Red()
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
            Assert.IsFalse(moveRed.IsValid(board), "Expected: Red Soldier Horizontal Move when not across the river to be invalid");
        }
    }
}
