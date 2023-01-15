using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Pieces;
using Xiangqi.UnitTests.PiecesTests;

namespace PiecesTests.ElephantTest
{
    [TestClass]
    public class Elephant_PieceMove : PieceMoveTestClass<Elephant>
    {
        [TestMethod]
        [DataRow("Black", 0, 2, 2, 0)]
        [DataRow("Black", 2, 0, 4, 2)]
        [DataRow("Black", 4, 2, 2, 4)]
        [DataRow("Black", 2, 4, 0, 2)]
        [DataRow("Red", 9, 6, 7, 4)]
        [DataRow("Red", 7, 4, 5, 6)]
        [DataRow("Red", 5, 6, 7, 8)]
        [DataRow("Red", 7, 8, 9, 6)]
        public void DiagonalValidMove(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsTrue(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: Elephant Diagonal Valid Move to be Valid"
            );
        }

        [TestMethod]
        [DataRow("Black", 0, 2, 1, 1)]
        [DataRow("Black", 0, 2, 3, 5)]
        [DataRow("Black", 0, 2, 4, 6)]
        public void DiagonalInvalidMove(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsFalse(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: Elephant Diagonal Move of wrong size to be Valid"
            );
        }

        [TestMethod]
        [DataRow("Black", 0, 2, 2, 2)]
        [DataRow("Black", 0, 2, 0, 0)]
        [DataRow("Black", 0, 2, 2, 1)]
        public void NonDiagonalMove(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsFalse(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: Elephant Non Diagonal Move to be Invalid"
            );
        }

        [TestMethod]
        [DataRow("Black", 4, 2, 6, 4)]
        [DataRow("Black", 4, 2, 6, 0)]
        [DataRow("Red", 5, 6, 3, 4)]
        [DataRow("Red", 5, 6, 3, 0)]
        public void OverTheRiver(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsFalse(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: Elephant Over the River Move to be Invalid"
            );
        }


        [TestMethod]
        [DataRow("Black", 0, 2, 2, 0, 1, 1)]
        [DataRow("Red", 9, 6, 7, 4, 8, 5)]
        public void DiagonalMove_WithBlocking_Invalid(string color, int oldRow, int oldCol, int newRow, int newCol, int blockRow, int blockCol)
        {
            Assert.IsFalse(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol, blockRow, blockCol),
                "Expected: Elephant Move Through Blocking to be Invalid"
            );
        }
    }
}
