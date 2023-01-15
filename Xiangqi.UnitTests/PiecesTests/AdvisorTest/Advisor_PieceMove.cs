using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Pieces;
using Xiangqi.UnitTests.PiecesTests;

namespace PiecesTests.AdvisorTest
{
    [TestClass]
    public class Advisor_PieceMove : PieceMoveTestClass<Advisor>
    {
        [TestMethod]
        [DataRow("Black", 1, 4, 0, 3)]
        [DataRow("Black", 1, 4, 0, 5)]
        [DataRow("Black", 1, 4, 2, 3)]
        [DataRow("Black", 1, 4, 2, 5)]
        [DataRow("Red", 8, 4, 7, 3)]
        [DataRow("Red", 8, 4, 7, 5)]
        [DataRow("Red", 8, 4, 9, 3)]
        [DataRow("Red", 8, 4, 9, 5)]
        public void DiagonalMove(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsTrue(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: Advisor Diagonal Move to be Valid"
            );
        }

        [TestMethod]
        [DataRow("Black", 1, 4, 1, 3)]
        [DataRow("Black", 1, 4, 1, 5)]
        [DataRow("Black", 1, 4, 0, 4)]
        [DataRow("Black", 1, 4, 2, 4)]
        [DataRow("Red", 8, 4, 8, 3)]
        [DataRow("Red", 8, 4, 8, 5)]
        [DataRow("Red", 8, 4, 7, 4)]
        [DataRow("Red", 8, 4, 9, 4)]
        public void NonDiagonalMove(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsFalse(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: Advisor Move that is not diagonal to be Invalid"
            );
        }

        [TestMethod]
        [DataRow("Black", 0, 3, 2, 5)]
        [DataRow("Black", 2, 3, 0, 5)]
        [DataRow("Red", 8, 3, 6, 5)]
        [DataRow("Red", 8, 5, 6, 3)]
        public void DiagonalMove_AcrossMultipleSquares(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsFalse(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: Advisor Move across multiple squares to be Invalid"
            );
        }



        [TestMethod]
        [DataRow("Black", 0, 3, 1, 2)]
        [DataRow("Black", 2, 5, 3, 6)]
        [DataRow("Red", 7, 3, 6, 2)]
        [DataRow("Red", 9, 5, 8, 6)]
        public void Move_OutOfCastle(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsFalse(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: General Moves Out of Castle to be Invalid"
            );
        }
    }
}
