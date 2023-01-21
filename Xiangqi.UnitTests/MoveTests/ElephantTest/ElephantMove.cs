using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;
using Xiangqi.UnitTests;

namespace PiecesTests.ElephantTest
{
    [TestClass]
    public class ElephantMove
    {
        [TestMethod]
        [DataRow(Color.Red, "c0a2")]
        [DataRow(Color.Red, "c0e2")]
        [DataRow(Color.Red, "c4a2")]
        [DataRow(Color.Red, "c4e2")]
        [DataRow(Color.Black, "c5a7")]
        [DataRow(Color.Black, "c5e7")]
        [DataRow(Color.Black, "c9a7")]
        [DataRow(Color.Black, "c9e7")]
        public void DiagonalValidMove(Color color, string move)
        {
            string board =
                " | |e| |k| | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | |e| | | | | | \n" +
                " | |E| | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | |E| | |K| | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsTrue(result, "Expected: Elephant Diagonal Valid Move to be Valid");
        }

        [TestMethod]
        [DataRow(Color.Red, "c0b1")]
        [DataRow(Color.Red, "c0f3")]
        [DataRow(Color.Red, "c0g4")]
        public void DiagonalInvalidMove(Color color, string move)
        {
            string board =
                " | |e| |k| | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | |e| | | | | | \n" +
                " | |E| | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | |E| | |K| | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Elephant Diagonal Invalid Move to be Invalid");
        }

        [TestMethod]
        [DataRow(Color.Red, "c0a0")]
        [DataRow(Color.Red, "c0c2")]
        [DataRow(Color.Red, "c0b2")]
        public void NonDiagonalMove(Color color, string move)
        {
            string board =
                " | |e| |k| | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | |e| | | | | | \n" +
                " | |E| | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | |E| | |K| | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Elephant Non Diagonal Move to be Invalid");
        }

        [TestMethod]
        [DataRow(Color.Red, "c4e6")]
        public void OverTheRiver(Color color, string move)
        {
            string board =
                " | |e| |k| | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | |e| | | | | | \n" +
                " | |E| | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | |E| | |K| | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Elephant Over the River Move to be Invalid");
        }

        [TestMethod]
        [DataRow(Color.Red, "c0e2")]
        public void DiagonalMove_WithBlocking_Invalid(Color color, string move)
        {
            string board =
                " | |e| |k| | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | |e| | | | | | \n" +
                " | |E| | | | | | \n" +
                " | | | | | | | | \n" +
                " | | | | | | | | \n" +
                " | | |p| | | | | \n" +
                " | |E| | |K| | | ";
            bool result = TestSupport.MoveIsValid(board, color, move);

            Assert.IsFalse(result, "Expected: Elephant Move Through Blocking to be Invalid");
        }
    }
}
