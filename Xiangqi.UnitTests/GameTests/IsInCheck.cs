using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game;
using Xiangqi.Game.Moves;

namespace Xiangqi.UnitTests.GameTests
{
    [TestClass]
    public class IsInCheck
    {
        [TestMethod]
        [DataRow(Color.Red, "a8a9")]
        public void Move_ResultingInOpponentCheck(Color color, string move)
        {
            string board =
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
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsTrue(result, "Expected: Move to Opponent Check to be Valid");
        }

        [TestMethod]
        [DataRow(Color.Red, "b0b9")]
        public void Move_ResultingInSelfCheck(Color color, string move)
        {
            string board =
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
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Move to Self Check to be Invalid");
        }
    }
}
