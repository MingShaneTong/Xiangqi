using Xiangqi.Game;
using Xiangqi.UnitTests;

namespace MoveTests.CannonTest
{
    [TestClass]
    public class CannonCapture
    {
        [TestMethod]
        [DataRow(Color.Red, "b0h0")]
        [DataRow(Color.Red, "b0b8")]
        [DataRow(Color.Black, "a9i9")]
        [DataRow(Color.Black, "a9a0")]
        public void ValidCapture(Color color, string move) 
        {
            var board =
                "c| | |k| | | | |P\n" +
                " |h| | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                "P|p| | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                "R|C| | | |K| |p| ";
            var result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsTrue(result, "Expected: Cannon Valid Capture to be Valid");
        }

        [TestMethod]
        [DataRow(Color.Red, "b0b5")]
        [DataRow(Color.Black, "a9a5")]
        public void NoJump_Capture(Color color, string move)
        {
            var board =
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
            var result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Cannon No Jump Capture to be Invalid");
        }



        [TestMethod]
        [DataRow(Color.Red, "b0b9")]
        [DataRow(Color.Black, "a9i9")]
        public void MultiplePieceJump_Capture(Color color, string move)
        {
            var board =
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
            var result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Cannon With Multiple Piece Jump Capture to be Invalid");
        }
    }
}
