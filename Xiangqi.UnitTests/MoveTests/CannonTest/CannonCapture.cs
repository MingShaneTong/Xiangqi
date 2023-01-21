using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game;
using Xiangqi.Game.Moves;
using Xiangqi.UnitTests;

namespace MoveTests.CannonTest
{
    [TestClass]
    public class CannonCapture
    {
        [TestMethod]
        [DataRow(Color.Black, "a9i9")]
        [DataRow(Color.Black, "a9a0")]
        [DataRow(Color.Red, "b0h0")]
        [DataRow(Color.Red, "b0b8")]
        public void ValidCapture(Color color, string move) 
        {
            string board =
                "c| | |k| | | | |P\n" +
                " |h| | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                "P|p| | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                "R|C| | | |K| |r| ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsTrue(result, "Expected: Cannon Valid Capture to be Valid");
        }

        [TestMethod]
        [DataRow(Color.Red, "b0b5")]
        [DataRow(Color.Black, "a9a5")]
        public void NoJump_Capture(Color color, string move)
        {
            string board =
                "c| | |k| | | | |P\n" +
                " |h| | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                "P|p| | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                "R|C| | | |K| |r| ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Cannon No Jump Capture to be Invalid");
        }



        [TestMethod]
        [DataRow(Color.Red, "b0b9")]
        [DataRow(Color.Black, "a9i9")]
        public void MultiplePieceJump_Capture(Color color, string move)
        {
            string board =
                "c|h|e|k| | | | |P\n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                "P|p| | | | | | | \n" +
                " |R| | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                "R|C| | | |K| |r| ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Cannon With Multiple Piece Jump Capture to be Invalid");
        }
    }
}
