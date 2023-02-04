using Xiangqi.Game;
using Xiangqi.UnitTests;

namespace MoveTests.CannonTest
{
    [TestClass]
    public class CannonMove
    {
        [TestMethod]
        [DataRow(Color.Red, "e4a4")]
        [DataRow(Color.Red, "e4i4")]
        [DataRow(Color.Black, "e5a5")]
        [DataRow(Color.Black, "e5i5")]
        public void HorizontalMove(Color color, string move)
        {
            var board =
                " | | |k| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | |c| | | | \n" +
                " | | | |C| | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | |K| | | ";
            var result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsTrue(result, "Expected: Cannon Horizontal Move to be Valid");
        }

        [TestMethod]
        [DataRow(Color.Red, "a4a0")]
        [DataRow(Color.Red, "a4a9")]
        [DataRow(Color.Black, "i5i0")]
        [DataRow(Color.Black, "i5i9")]
        public void VerticalMove(Color color, string move)
        {
            var board =
                " | | |k| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | |c\n" +
                "C| | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | |K| | | ";
            var result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsTrue(result, "Expected: Cannon Vertical Move to be Valid");
        }

        [TestMethod]
        [DataRow(Color.Red, "a0e4")]
        [DataRow(Color.Black, "a9e5")]
        public void DiagonalMove(Color color, string move)
        {
            var board =
                "c| | |k| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                "C| | | | |K| | | ";
            var result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Cannon Diagonal Move to be Invalid");
        }

        [TestMethod]
        [DataRow(Color.Red, "a0i0")]
        [DataRow(Color.Black, "a9i9")]
        public void HorizontalMove_WithBlocking_Invalid(Color color, string move)
        {
            var board =
                "c| | |k| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                "C| | | | |K| | | ";
            var result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Cannon Horizontal Move Through Blocking to be Invalid");
        }

        [TestMethod]
        [DataRow(Color.Red, "b0b9")]
        [DataRow(Color.Black, "a9a0")]
        public void VerticalMove_WithBlocking_Invalid(Color color, string move)
        {
            var board =
                "c| | |k| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                "P|p| | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " |C| | | |K| | | ";
            var result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Cannon Vertical Move Through Blocking to be Invalid");
        }
    }
}
