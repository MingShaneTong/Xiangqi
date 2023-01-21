using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;
using Xiangqi.UnitTests;

namespace PiecesTests.HorseTest
{
    [TestClass]
    public class HorseMove
    {
        [TestMethod]
        [DataRow(Color.Red, "g0e1")]
        [DataRow(Color.Red, "g0f2")]
        [DataRow(Color.Red, "g0h2")]
        [DataRow(Color.Red, "g0i1")]
        [DataRow(Color.Black, "c9a8")]
        [DataRow(Color.Black, "c9b7")]
        [DataRow(Color.Black, "c9d7")]
        [DataRow(Color.Black, "c9e8")]
        public void ValidMove(Color color, string move)
        {
            string board =
                " | |h| | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | |k| | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | |K| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | |H| | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsTrue(result, "Expected: Horse Valid Move to be Valid");
        }

        [TestMethod]
        [DataRow(Color.Red, "g0i2")]
        [DataRow(Color.Red, "g0h1")]
        [DataRow(Color.Red, "g0g1")]
        [DataRow(Color.Red, "g0g2")]
        [DataRow(Color.Black, "c9b9")]
        [DataRow(Color.Black, "c9a9")]
        public void InvalidMove(Color color, string move)
        {
            string board =
                " | |h| | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | |k| | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | |K| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | |H| | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Horse Invalid Move to be Invalid");
        }


        [TestMethod]
        [DataRow(Color.Red, "g0e1")]
        [DataRow(Color.Red, "g0f2")]
        [DataRow(Color.Red, "g0h2")]
        [DataRow(Color.Red, "g0i1")]
        [DataRow(Color.Black, "c9a8")]
        [DataRow(Color.Black, "c9b7")]
        [DataRow(Color.Black, "c9d7")]
        [DataRow(Color.Black, "c9e8")]
        public void Move_WithBlocking_Invalid(Color color, string move)
        {
            string board =
                " |P|h|P| | | | | \n" +
                " | |P| | | | | | \n" +
                " | | | | |k| | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | |K| | | | | \n" +
                " | | | | | |p| | \n" +
                " | | | | |p|H|p| ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Horse Move Through Blocking to be Invalid");
        }
    }
}
