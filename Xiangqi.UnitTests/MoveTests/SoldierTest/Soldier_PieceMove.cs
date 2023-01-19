using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;
using Xiangqi.Game;
using Xiangqi.UnitTests.PiecesTests;

namespace PiecesTests.SoldierTest
{
    [TestClass]
    public class Soldier_PieceMove : MoveTestClass<Pawn>
    {
        [TestMethod]
        [DataRow("Black", 5, 0, 5, 1)]
        [DataRow("Black", 5, 2, 5, 1)]
        [DataRow("Red", 4, 0, 4, 1)]
        [DataRow("Red", 4, 2, 4, 1)]
        public void HorizontalMove(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsTrue(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol), 
                "Expected: Soldier Horizontal Move to be Valid"
            );
        }

        [TestMethod]
        [DataRow("Black", 5, 0, 5, 2)]
        [DataRow("Black", 5, 4, 5, 2)]
        [DataRow("Red", 4, 0, 4, 2)]
        [DataRow("Red", 4, 4, 4, 2)]
        public void HorizontalMove_AcrossMultipleSquares(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsFalse(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: Soldier Horizontal Move across multiple squares to be Invalid"
            );
        }

        [TestMethod]
        [DataRow("Black", 3, 0, 3, 1)]
        [DataRow("Black", 4, 4, 4, 3)]
        [DataRow("Red", 6, 0, 6, 1)]
        [DataRow("Red", 5, 4, 5, 3)]
        public void HorizontalMove_NotOverRiver(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsFalse(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: Soldier Horizontal Move when not across the river to be Invalid"
            );
        }

        [TestMethod]
        [DataRow("Black", 3, 0, 4, 0)]
        [DataRow("Black", 4, 0, 5, 0)]
        [DataRow("Red", 6, 2, 5, 2)]
        [DataRow("Red", 5, 4, 4, 4)]
        public void ForwardMove(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsTrue(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol), 
                "Expected: Soldier Forward Move to be Valid"
            );
        }

        [TestMethod]
        [DataRow("Black", 3, 0, 2, 0)]
        [DataRow("Black", 5, 0, 4, 0)]
        [DataRow("Red", 6, 2, 7, 2)]
        [DataRow("Red", 4, 4, 5, 4)]
        public void BackwardMove(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsFalse(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: Soldier Backward Move to be Invalid"
            );
        }

        [TestMethod]
        [DataRow("Black", 3, 0, 5, 0)]
        [DataRow("Black", 5, 0, 7, 0)]
        [DataRow("Red", 6, 2, 4, 2)]
        [DataRow("Red", 5, 4, 7, 4)]
        public void ForwardMove_AcrossMultipleSquares(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsFalse(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: Soldier Forward across multiple squares to be Invalid"
            );
        }
    }
}
