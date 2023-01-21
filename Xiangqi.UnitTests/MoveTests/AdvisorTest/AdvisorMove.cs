using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;
using Xiangqi.UnitTests;

namespace PiecesTests.AdvisorTest
{
    [TestClass]
    public class AdvisorMove
    {
        [TestMethod]
        [DataRow(Color.Red, "e1d0")]
        [DataRow(Color.Red, "e1f0")]
        [DataRow(Color.Red, "e1d2")]
        [DataRow(Color.Red, "e1f2")]
        [DataRow(Color.Black, "e8d7")]
        [DataRow(Color.Black, "e8f7")]
        [DataRow(Color.Black, "e8d9")]
        [DataRow(Color.Black, "e8f9")]
        public void DiagonalMove(Color color, string move)
        {
            string board =
                " | | | |k| | | | \n" +
                " | | | |a| | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | |A| | | | \n" +
                " | | | |K| | | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsTrue(result, "Expected: Advisor Diagonal Move to be Valid");
        }

        [TestMethod]
        [DataRow(Color.Red, "e1d1")]
        [DataRow(Color.Red, "e1f1")]
        [DataRow(Color.Red, "e1e0")]
        [DataRow(Color.Red, "e1e2")]
        [DataRow(Color.Black, "e8d8")]
        [DataRow(Color.Black, "e8f8")]
        [DataRow(Color.Black, "e8e7")]
        [DataRow(Color.Black, "e8e9")]
        public void NonDiagonalMove(Color color, string move)
        {
            string board =
                " | | | |k| | | | \n" +
                " | | | |a| | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | |A| | | | \n" +
                " | | | |K| | | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Advisor Move that is not diagonal to be Invalid");
        }

        [TestMethod]
        [DataRow(Color.Red, "d0f2")]
        [DataRow(Color.Black, "d9f7")]
        public void DiagonalMove_AcrossMultipleSquares(Color color, string move)
        {
            string board =
                " | | |a|k| | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | |A| |K| | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Advisor Move across multiple squares to be Invalid");
        }

        [TestMethod]
        [DataRow(Color.Red, "d2c3")]
        [DataRow(Color.Black, "d7c6")]
        public void Move_OutOfCastle(Color color, string move)
        {
            string board =
                " | | | |k| | | | \n" +
                " | | | | | | | | \n" +
                " | | |a| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | |A| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | |K| | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Advisor Moves Out of Castle to be Invalid");
        }
    }
}
