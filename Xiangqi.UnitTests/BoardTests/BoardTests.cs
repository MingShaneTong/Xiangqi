using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game;

namespace Xiangqi.UnitTests.BoardTests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void GetPositionSide_Test()
        {
            for (int row = 0; row < 5; row++)
            { 
                for (int col = 0; col < Board.Cols; col++)
                {
                    Assert.IsTrue(Board.GetPositionSide(new Position(row, col)) == Color.Black);
                }
            }

            for (int row = 5; row < Board.Rows; row++)
            {
                for (int col = 0; col < Board.Cols; col++)
                {
                    Assert.IsTrue(Board.GetPositionSide(new Position(row, col)) == Color.Red);
                }
            }
        }


        [TestMethod]
        public void InCastle_Test()
        {
            ISet<Position> blackCastlePositions = new HashSet<Position> {
                new Position(0, 3), new Position(0, 4), new Position(0, 5),
                new Position(1, 3), new Position(1, 4), new Position(1, 5),
                new Position(2, 3), new Position(2, 4), new Position(2, 5),
            };
            ISet<Position> redCastlePositions = new HashSet<Position> {
                new Position(7, 3), new Position(7, 4), new Position(7, 5),
                new Position(8, 3), new Position(8, 4), new Position(8, 5),
                new Position(9, 3), new Position(9, 4), new Position(9, 5),
            };

            for (int row = 0; row < Board.Rows; row++)
            {
                for (int col = 0; col < Board.Cols; col++)
                {
                    Position position = new Position(row, col);
                    Assert.AreEqual(
                        blackCastlePositions.Contains(position),
                        Board.InCastle(Color.Black, position),
                        "Error on Black Castle Identification at " + position.ToString()
                    );
                    Assert.AreEqual(
                        redCastlePositions.Contains(position),
                        Board.InCastle(Color.Red, position),
                        "Error on Red Castle Identification at " + position.ToString()
                    );
                }
            }
        }
    }
}
