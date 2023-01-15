using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;
using Xiangqi.Game;
using Xiangqi.UnitTests.PiecesTests;

namespace PiecesTests.CannonTest
{
    [TestClass]
    public class Cannon_PieceMove : PieceMoveTestClass<Cannon>
    {
        [TestMethod]
        [DataRow("Black", 0, 0, 0, 8)]
        [DataRow("Black", 0, 7, 0, 2)]
        [DataRow("Red", 9, 8, 9, 0)]
        [DataRow("Red", 9, 2, 9, 7)]
        public void HorizontalMove(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsTrue(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: Cannon Horizontal Move to be Valid"
            );
        }

        [TestMethod]
        [DataRow("Black", 0, 0, 9, 0)]
        [DataRow("Black", 2, 0, 7, 0)]
        [DataRow("Red", 9, 0, 0, 0)]
        [DataRow("Red", 7, 0, 2, 0)]
        public void VerticalMove(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsTrue(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: Cannon Vertical Move to be Valid"
            );
        }

        [TestMethod]
        [DataRow("Black", 0, 0, 5, 5)]
        [DataRow("Red", 5, 5, 8, 8)]
        public void DiagonalMove(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Assert.IsFalse(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol),
                "Expected: Cannon Diagonal Move to be Invalid"
            );
        }

        [TestMethod]
        [DataRow("Black", 0, 0, 0, 8, 0, 1)]
        [DataRow("Red", 9, 7, 9, 1, 9, 4)]
        public void HorizontalMove_WithBlocking_Invalid(string color, int oldRow, int oldCol, int newRow, int newCol, int blockRow, int blockCol)
        {
            Assert.IsFalse(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol, blockRow, blockCol),
                "Expected: Cannon Horizontal Move Through Blocking to be Invalid"
            );
        }

        [TestMethod]
        [DataRow("Black", 0, 0, 9, 0, 2, 0)]
        [DataRow("Red", 8, 0, 1, 0, 4, 0)]
        public void VerticalMove_WithBlocking_Invalid(string color, int oldRow, int oldCol, int newRow, int newCol, int blockRow, int blockCol)
        {
            Assert.IsFalse(
                MoveIsValid(color, oldRow, oldCol, newRow, newCol, blockRow, blockCol),
                "Expected: Cannon Vertical Move Through Blocking to be Invalid"
            );
        }
    }
}
