using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;
using Xiangqi.Game;
using Xiangqi.UnitTests;

namespace MoveTests.KingTest
{
    [TestClass]
    public class KingMove
    {
        [TestMethod]
        [DataRow(Color.Red, "e0d0")]
        [DataRow(Color.Red, "e0f0")]
        [DataRow(Color.Black, "e9d9")]
        [DataRow(Color.Black, "e9f9")]
        public void HorizontalMove(Color color, string move)
        {
            string board =
                " | | | |k| | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | |P| | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | |K| | | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsTrue(result, "Expected: King Horizontal Move to be Valid");
        }


        [TestMethod]
        [DataRow(Color.Red, "e1e0")]
        [DataRow(Color.Red, "e1e2")]
        [DataRow(Color.Black, "e8e7")]
        [DataRow(Color.Black, "e8e9")]
        public void VerticalMove(Color color, string move)
        {
            string board =
                " | | | | | | | | \n" +
                " | | | |k| | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | |P| | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | |K| | | | \n" +
                " | | | | | | | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsTrue(result, "Expected: King Vertical Move to be Valid");
        }

        [TestMethod]
        [DataRow(Color.Red, "d0f0")]
        [DataRow(Color.Black, "d9f9")]
        public void HorizontalMove_AcrossMultipleSquares(Color color, string move)
        {
            string board =
                " | | |k| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | |P| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | |K| | | | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: King Horizontal Move Across Multiple Squares to be Invalid");
        }

        [TestMethod]
        [DataRow(Color.Red, "d0d2")]
        [DataRow(Color.Black, "d9d7")]
        public void VerticalMove_AcrossMultipleSquares(Color color, string move)
        {
            string board =
                " | | |k| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | |P| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | |K| | | | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: King Vertical Move Across Multiple Squares to be Invalid");
        }

        [TestMethod]
        [DataRow(Color.Red, "d0e1")]
        [DataRow(Color.Black, "d9e8")]
        public void DiagonalMove(Color color, string move)
        {
            string board =
                " | | |k| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | |P| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | |K| | | | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: King Diagonal Move to be Invalid");
        }

        [TestMethod]
        [DataRow(Color.Red, "d2d3")]
        [DataRow(Color.Red, "d2c2")]
        [DataRow(Color.Black, "d7d6")]
        [DataRow(Color.Black, "d7c6")]
        public void Move_OutOfCastle(Color color, string move)
        {
            string board =
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | |k| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | |P| | | | | \n" +
                " | | | | | | | | \n" +
                " | | |K| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: King Moves Out of Castle to be Invalid");
        }
    }
}
