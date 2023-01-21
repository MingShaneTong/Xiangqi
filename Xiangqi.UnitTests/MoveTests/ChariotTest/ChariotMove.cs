using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;
using Xiangqi.Game;
using Xiangqi.UnitTests;

namespace MoveTests.ChariotTest
{
    [TestClass]
    public class ChariotMove
    {
        [TestMethod]
        [DataRow(Color.Red, "e4a4")]
        [DataRow(Color.Red, "e4i4")]
        [DataRow(Color.Black, "e5a5")]
        [DataRow(Color.Black, "e5i5")]
        public void HorizontalMove(Color color, string move)
        {
            string board =
                " | | |k| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | |r| | | | \n" +
                " | | | |R| | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | |K| | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsTrue(result, "Expected: Soldier Horizontal Move to be Valid");
        }

        [TestMethod]
        [DataRow(Color.Red, "a4a0")]
        [DataRow(Color.Red, "a4a9")]
        [DataRow(Color.Black, "i5i0")]
        [DataRow(Color.Black, "i5i9")]
        public void VerticalMove(Color color, string move)
        {
            string board =
                " | | |k| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | |r\n" +
                "R| | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | |K| | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsTrue(result, "Expected: Soldier Vertical Move to be Valid");
        }

        [TestMethod]
        [DataRow(Color.Red, "a0e4")]
        [DataRow(Color.Black, "a9e5")]
        public void DiagonalMove(Color color, string move)
        {
            string board =
                "r| | |k| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                "R| | | | |K| | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Chariot Diagonal Move to be Invalid");
        }

        [TestMethod]
        [DataRow(Color.Red, "a0i0")]
        [DataRow(Color.Black, "a9i9")]
        public void HorizontalMove_WithBlocking_Invalid(Color color, string move)
        {
            string board =
                "r| | |k| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                "R| | | | |K| | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Chariot Horizontal Move Through Blocking to be Invalid");
        }

        [TestMethod]
        [DataRow(Color.Red, "b0b9")]
        [DataRow(Color.Black, "a9a0")]
        public void VerticalMove_WithBlocking_Invalid(Color color, string move)
        {
            string board =
                "r| | |k| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                "P|p| | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " |R| | | |K| | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Chariot Vertical Move Through Blocking to be Invalid");
        }
    }
}
