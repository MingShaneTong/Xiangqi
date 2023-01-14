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
    public class PreCondition
    {
        [TestMethod]
        public void InvalidNoMove()
        {
            IPiece soldier = Soldier.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(3, 6), soldier }
            });

            IMove moveBlack = new PieceMove()
            {
                OldPosition = new Position(3, 6),
                NewPosition = new Position(3, 6),
                Piece = soldier
            };
            Assert.IsFalse(moveBlack.IsValid(board), "Soldier No Move Valid");
        }

        [TestMethod]
        public void InvalidOldPosition()
        {
            IPiece soldier = Soldier.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(3, 0), soldier }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(3, -1),
                NewPosition = new Position(3, 0),
                Piece = soldier
            };
            Assert.IsFalse(move.IsValid(board), "Soldier Old Position Valid");
        }


        [TestMethod]
        public void InvalidNewPosition()
        {
            IPiece soldier = Soldier.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(3, 0), soldier }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(3, 0),
                NewPosition = new Position(3, -1),
                Piece = soldier
            };
            Assert.IsFalse(move.IsValid(board), "Soldier New Position Valid");
        }

        [TestMethod]
        public void InvalidOldAndNewPosition()
        {
            IPiece soldier = Soldier.Of(Color.Black);
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { new Position(3, 0), soldier }
            });

            IMove move = new PieceMove()
            {
                OldPosition = new Position(3, -1),
                NewPosition = new Position(3, -2),
                Piece = soldier
            };
            Assert.IsFalse(move.IsValid(board), "Soldier Old And New Position Valid");
        }

        [TestMethod]
        public void InvalidWrongPiecePositions()
        {
            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>());

            IMove move = new PieceMove()
            {
                OldPosition = new Position(3, 6),
                NewPosition = new Position(3, 7),
                Piece = Soldier.Of(Color.Black)
            };
            Assert.IsFalse(move.IsValid(board), "Wrong Piece Move Valid");
        }
    }
}
