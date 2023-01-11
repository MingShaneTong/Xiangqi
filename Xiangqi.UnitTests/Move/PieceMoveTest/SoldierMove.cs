using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;

namespace Xiangqi.UnitTests.Move.PieceMoveTest
{
    [TestClass]
    public class SoldierMove
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
            Assert.IsTrue(moveBlack.IsValid(board), "Black Soldier Move Not Valid");
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
            Assert.IsTrue(moveRed.IsValid(board), "Red Soldier Move Not Valid");
        }
    }
}
