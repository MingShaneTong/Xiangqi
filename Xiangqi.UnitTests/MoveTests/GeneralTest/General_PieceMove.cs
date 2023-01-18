using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;
using Xiangqi.Game;
using Xiangqi.UnitTests.PiecesTests;

namespace PiecesTests.GeneralTest
{
    [TestClass]
    public class General_PieceMove : MoveTestClass<General>
    {
        [TestMethod]
        [DataRow("Black", 0, 3, 0, 4)]
        [DataRow("Black", 2, 5, 2, 4)]
        [DataRow("Red", 7, 4, 7, 3)]
        [DataRow("Red", 9, 4, 9, 5)]
        public void HorizontalMove(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsTrue(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: General Valid Move to be Valid"
            );
        }

        [TestMethod]
        [DataRow("Black", 1, 4, 2, 4)]
        [DataRow("Black", 1, 4, 0, 4)]
        [DataRow("Red", 8, 4, 7, 4)]
        [DataRow("Red", 8, 4, 9, 4)]
        public void VerticalMove(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsTrue(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: General Vertical Move to be Valid"
            );
        }

        [TestMethod]
        [DataRow("Black", 0, 3, 0, 5)]
        [DataRow("Black", 2, 5, 2, 3)]
        [DataRow("Red", 9, 3, 9, 5)]
        [DataRow("Red", 7, 5, 7, 3)]
        public void HorizontalMove_AcrossMultipleSquares(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsFalse(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol), 
                "Expected: General Horizontal Move Across Multiple Squares to be Invalid"
            );
        }

        [TestMethod]
        [DataRow("Black", 0, 3, 2, 3)]
        [DataRow("Black", 2, 5, 0, 5)]
        [DataRow("Red", 9, 3, 7, 3)]
        [DataRow("Red", 7, 5, 9, 5)]
        public void VerticalMove_AcrossMultipleSquares(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsFalse(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: General Vertical Move Across Multiple Squares to be Invalid"
            );
        }

        [TestMethod]
        [DataRow("Black", 0, 4, 1, 3)]
        [DataRow("Black", 0, 4, 1, 5)]
        [DataRow("Red", 9, 4, 8, 3)]
        [DataRow("Red", 9, 4, 8, 5)]
        public void DiagonalMove(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsFalse(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: General Diagonal Move to be Invalid"
            );
        }

        [TestMethod]
        [DataRow("Black", 2, 3, 2, 2)]
        [DataRow("Black", 2, 5, 3, 5)]
        [DataRow("Red", 7, 3, 6, 3)]
        [DataRow("Red", 7, 5, 7, 6)]
        public void Move_OutOfCastle(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsFalse(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol), 
                "Expected: General Moves Out of Castle to be Invalid"
            );
        }
    }
}
