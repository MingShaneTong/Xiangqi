using Xiangqi.Game;

namespace Xiangqi.UnitTests.GameTests
{
    [TestClass]
    public class IsInCheck
    {
        [TestMethod]
        [DataRow(Color.Red, "a8a9")]
        public void Move_ResultingInOpponentCheck(Color color, string move)
        {
            var board =
                " | | | |k| | | | \n" +
                "R| | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | |K| | | | | ";
            var result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsTrue(result, "Expected: Move to Opponent Check to be Valid");
        }

        [TestMethod]
        [DataRow(Color.Red, "b0b9")]
        public void Move_ResultingInSelfCheck(Color color, string move)
        {
            var board =
                " | | | |k| | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                "r|R| |K| | | | | ";
            var result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Move to Self Check to be Invalid");
        }

        [TestMethod]
        [DataRow(Color.Red, "d4e4")]
        public void Move_ResultingInBothCheck(Color color, string move)
        {
            var board =
                " | | | |k| | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | |r| | | | | \n" +
                " | | |R| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | |K| | | | | ";
            var result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Move to Both Check to be Invalid");
        }

        [TestMethod]
        [DataRow(Color.Red, "e5f7")]
        public void Move_ResultingInCheckAndKingFacing(Color color, string move)
        {
            var board =
                " | | | |k| | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | |H| | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | |K| | | | ";
            var result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Move to Check and King Facing to be Invalid");
        }
    }
}
