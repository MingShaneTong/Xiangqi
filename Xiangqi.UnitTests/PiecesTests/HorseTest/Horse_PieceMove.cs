using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Pieces;
using Xiangqi.UnitTests.PiecesTests;

namespace PiecesTests.HorseTest
{
    [TestClass]
    public class Horse_PieceMove : PieceMoveTestClass<Horse>
    {
        [TestMethod]
        [DataRow("Black", 0, 2, 1, 0)]
        [DataRow("Black", 0, 2, 2, 1)]
        [DataRow("Black", 0, 2, 2, 3)]
        [DataRow("Black", 0, 2, 1, 4)]
        [DataRow("Red", 9, 6, 8, 4)]
        [DataRow("Red", 9, 6, 7, 5)]
        [DataRow("Red", 9, 6, 7, 7)]
        [DataRow("Red", 9, 6, 8, 8)]
        public void ValidMove(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsTrue(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: Horse Valid Move to be Valid"
            );
        }

        [TestMethod]
        [DataRow("Black", 0, 1, 1, 2)]
        [DataRow("Black", 0, 1, 2, 3)]
        [DataRow("Black", 0, 1, 3, 4)]
        public void DiagonalMove(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsFalse(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: Horse Diagonal Move to be Invalid"
            );
        }

        [TestMethod]
        [DataRow("Black", 0, 1, 1, 1)]
        [DataRow("Black", 0, 1, 2, 1)]
        [DataRow("Black", 0, 1, 3, 1)]
        [DataRow("Black", 0, 1, 0, 2)]
        [DataRow("Black", 0, 1, 0, 3)]
        [DataRow("Black", 0, 1, 0, 4)]
        [DataRow("Black", 0, 1, 3, 2)]
        [DataRow("Black", 0, 1, 3, 3)]
        public void NonDiagonalMove(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsFalse(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: Horse Non Diagonal Move to be Invalid"
            );
        }

        [TestMethod]
        [DataRow("Black", 0, 2, 1, 0, 0, 1)]
        [DataRow("Black", 0, 2, 2, 1, 1, 2)]
        [DataRow("Black", 0, 2, 2, 3, 1, 2)]
        [DataRow("Black", 0, 2, 1, 4, 0, 3)]
        [DataRow("Red", 9, 6, 8, 4, 9, 5)]
        [DataRow("Red", 9, 6, 7, 5, 8, 6)]
        [DataRow("Red", 9, 6, 7, 7, 8, 6)]
        [DataRow("Red", 9, 6, 8, 8, 9, 7)]
        public void Move_WithBlocking_Invalid(string color, int oldRow, int oldCol, int newRow, int newCol, int blockRow, int blockCol)
        {
            Assert.IsFalse(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol, blockRow, blockCol),
                "Expected: Horse Move Through Blocking to be Invalid"
            );
        }
    }
}
