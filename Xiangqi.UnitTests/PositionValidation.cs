using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game;
using Xiangqi.Game.Pieces;

namespace Xiangqi.UnitTests
{
    [TestClass]
    public class PositionValidation
    {
        private void AssertPositionValid(Position position)
        {
            Assert.IsTrue(position.IsValid(), position.ToString() + " is not valid");
        }

        private void AssertPositionInvalid(Position position)
        {
            Assert.IsFalse(position.IsValid(), position.ToString() + " is valid");
        }

        [TestMethod]
        public void ValidPosition()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    AssertPositionValid(new Position(i, j));
                }
            }
        }

        [TestMethod]
        public void InvalidPosition()
        {
            AssertPositionInvalid(new Position(0, -1));
            AssertPositionInvalid(new Position(-1, 0));
            AssertPositionInvalid(new Position(0, 9));
            AssertPositionInvalid(new Position(10, 0));

            AssertPositionInvalid(new Position(-1, -1));
            AssertPositionInvalid(new Position(-1, 9));
            AssertPositionInvalid(new Position(10, -1));
            AssertPositionInvalid(new Position(10, 9));
        }
    }
}
