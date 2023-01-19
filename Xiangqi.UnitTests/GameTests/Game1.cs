using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game;

namespace Xiangqi.UnitTests.GameTests
{
    [TestClass]
    public class Game1
    {
        public void PerformRound(ChessGame game, string red, string black)
        {
            game.PerformTurn(red);
            game.PerformTurn(black);
        }

        [TestMethod]
        public void Game()
        {
            ChessGame game = new ChessGame();
            PerformRound(game, "h2e2", "h9g7");
            PerformRound(game, "h0g2", "i9h9");
            PerformRound(game, "c3c4", "h7i7");
            PerformRound(game, "b0c2", "g6g5");
            PerformRound(game, "c2d4", "b9c7");
            PerformRound(game, "i0i1", "d9e8");
            PerformRound(game, "i1c1", "c9e7");
            PerformRound(game, "e2d2", "h9h6");
            PerformRound(game, "c0e2", "e6e5");
            PerformRound(game, "b2b4", "a6a5");
            PerformRound(game, "d0e1", "a9a6");
            PerformRound(game, "d4f3", "h6e6");
            PerformRound(game, "g3g4", "a6b6");
            PerformRound(game, "b4b7", "g5g4");
            PerformRound(game, "b7a7", "g4g3");
            PerformRound(game, "a3a4", "g7f5");
            PerformRound(game, "a4a5", "f5h4");
            PerformRound(game, "f3g5", "e6g6");

            PerformRound(game, "g5h3", "i7h7");
            PerformRound(game, "g2i1", "g3h3");
            PerformRound(game, "c1c0", "h7h6");
            PerformRound(game, "a0b0", "c6c5");
            PerformRound(game, "c4c5", "e7c5");
            PerformRound(game, "b0b6", "g6b6");
            PerformRound(game, "c0c5", "c7a8");
            PerformRound(game, "c5c4", "h4f3");
            PerformRound(game, "i1h3", "b6b0");
            PerformRound(game, "d2d0", "b0b3");
            PerformRound(game, "d0d1", "h6e6");
            PerformRound(game, "c4f4", "f3h2");
            PerformRound(game, "a7h7", "h2i0");
            PerformRound(game, "h3g5", "e6e3");
            PerformRound(game, "h7h0", "i0h2");
            PerformRound(game, "h0h1", "a8b6");
            PerformRound(game, "g5h7", "h2f3");
            PerformRound(game, "h7f6", "f3g1");

            PerformRound(game, "f4f1", "b6c4");
            PerformRound(game, "h1h2", "c4a5");
            PerformRound(game, "f6d5", "g1h3");
            PerformRound(game, "d5e3", "b3e3");
            PerformRound(game, "f1f6", "i6i5");
            PerformRound(game, "f6g6", "g9e7");
            PerformRound(game, "g6g7", "e3d3");
            PerformRound(game, "e1d2", "h3f2");
            PerformRound(game, "d1f1", "d3h3");
            PerformRound(game, "h2g2", "a5c6");
            PerformRound(game, "f0e1", "f2e4");
            PerformRound(game, "f1g1", "h3h1");
            PerformRound(game, "g2i2", "e4g5");
            PerformRound(game, "i2i5", "g5f7");
            PerformRound(game, "i3i4", "c6d4");
            PerformRound(game, "i5i9", "h1h9");
            PerformRound(game, "g1i1", "d4f3");
            PerformRound(game, "g7g3", "f3g5");
            PerformRound(game, "i4i5", "e5e4");
            PerformRound(game, "i9i7", "e7g9");

            PerformRound(game, "i7i8", "e4f4");
            PerformRound(game, "g3b3", "h9h8");
            PerformRound(game, "i8i9", "g5h3");
            PerformRound(game, "i5i6", "f7g5");
            PerformRound(game, "i1f1", "h8h9");
            PerformRound(game, "i9i8", "h9h8");
            PerformRound(game, "i6i7", "f4e4");
            PerformRound(game, "f1f5", "e8d9");
            PerformRound(game, "i8i9", "h8a8");
            PerformRound(game, "f5c5", "h3g1");
            PerformRound(game, "e0d0", "g1f3");
            PerformRound(game, "c5c9", "d9e8");
            PerformRound(game, "b3b9", "a8a0");
            PerformRound(game, "c9c0", "e8d9");
            PerformRound(game, "b9b7", "d9e8");
            PerformRound(game, "i7h7", "f3d4");
            PerformRound(game, "h7g7", "g5f3");
            PerformRound(game, "g7g8", "d4c2");
            PerformRound(game, "d0e0", "f3g1");
            PerformRound(game, "e0f0", "a0a6");
            PerformRound(game, "i9i2", "e4e3");
            PerformRound(game, "i2f2", "a6g6");
            PerformRound(game, "b7b2", "e3f3");

            PerformRound(game, "f2f1", "g6g8");
            PerformRound(game, "b2c2", "g8g6");
            PerformRound(game, "c2c3", "g6e6");
            PerformRound(game, "c0e0", "e6b6");
            PerformRound(game, "e1f2", "e9d9");
            PerformRound(game, "f1d1", "e8d7");
            game.PerformTurn("d2e1");

            Trace.WriteLine(game.Board.ToString());
        }
    }
}
