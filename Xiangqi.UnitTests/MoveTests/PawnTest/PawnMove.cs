using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;
using Xiangqi.Game;
using Xiangqi.UnitTests;

namespace PiecesTests.PawnTest
{
    [TestClass]
    public class PawnMove
    {
        [TestMethod]
        [DataRow(Color.Red, "c5b5")]
        [DataRow(Color.Red, "c5d5")]
        [DataRow(Color.Black, "b4a4")]
        [DataRow(Color.Black, "b4c4")]
        public void HorizontalMove(Color color, string move)
        {
            string board =
                " | | |k| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | |P| | | | | | \n" +
                " |p| | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | |K| | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);
            
            Assert.IsTrue(result, "Expected: Soldier Horizontal Move to be Valid");
        }

        [TestMethod]
        [DataRow(Color.Red, "c4a4")]
        [DataRow(Color.Red, "c4e4")]
        [DataRow(Color.Black, "c5a5")]
        [DataRow(Color.Black, "c5e5")]
        public void HorizontalMove_AcrossMultipleSquares(Color color, string move)
        {
            string board =
                " | | |k| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | |p| | | | | | \n" +
                " | |P| | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | |K| | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Soldier Horizontal Move across multiple squares to be Invalid");
        }

        [TestMethod]
        [DataRow(Color.Red, "b4c4")]
        [DataRow(Color.Red, "b4a4")]
        [DataRow(Color.Black, "b5c5")]
        [DataRow(Color.Black, "b5a5")]
        public void HorizontalMove_NotOverRiver(Color color, string move)
        {
            string board =
                " | | |k| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " |p| | | | | | | \n" +
                " |P| | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | |K| | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);
            Assert.IsFalse(result, "Expected: Soldier Horizontal Move when not across the river to be Invalid");
        }

        [TestMethod]
        [DataRow(Color.Red, "a3a4")]
        [DataRow(Color.Black, "b6b5")]
        public void ForwardMove(Color color, string move)
        {
            string board =
                " | | |k| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " |p| | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                "P| | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | |K| | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);
            Assert.IsTrue(result, "Expected: Soldier Forward Move to be Valid");
        }

        [TestMethod]
        [DataRow(Color.Red, "a3a2")]
        [DataRow(Color.Black, "b6b7")]
        public void BackwardMove(Color color, string move)
        {
            string board =
                " | | |k| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " |p| | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                "P| | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | |K| | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);
            Assert.IsFalse(result, "Expected: Soldier Backward Move to be Invalid");
        }

        [TestMethod]
        [DataRow(Color.Red, "a3a5")]
        [DataRow(Color.Black, "b6b4")]
        public void ForwardMove_AcrossMultipleSquares(Color color, string move)
        {
            string board =
                " | | |k| | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " |p| | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                "P| | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | |K| | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);
            Assert.IsFalse(result, "Expected: Soldier Forward across multiple squares to be Invalid");
        }
    }
}
