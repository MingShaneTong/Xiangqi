using System.Diagnostics;
using Xiangqi.Game;

namespace Xiangqi.UnitTests
{
    [TestClass]
    public class BoardState
    {
        [TestMethod]
        public void InitialBoardPosition()
        {
            Board board = BoardCreator.InitBoard();
            Trace.WriteLine(board);
            Assert.AreEqual(board.ToString(),
                "車|馬|象|士|将|士|象|馬|車\n" +
                "。|。|。|。|。|。|。|。|。\n" +
                "。|砲|。|。|。|。|。|砲|。\n" +
                "卒|。|卒|。|卒|。|卒|。|卒\n" +
                "。|。|。|。|。|。|。|。|。\n" +
                "。|。|。|。|。|。|。|。|。\n" +
                "兵|。|兵|。|兵|。|兵|。|兵\n" +
                "。|炮|。|。|。|。|。|炮|。\n" +
                "。|。|。|。|。|。|。|。|。\n" +
                "俥|傌|相|仕|帥|仕|相|傌|俥"
            );
        }
    }
}