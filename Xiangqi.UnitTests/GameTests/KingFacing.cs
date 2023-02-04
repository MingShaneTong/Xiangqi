using Xiangqi.Game;
using Xiangqi.Game.Pieces;

namespace Xiangqi.UnitTests.GameTests
{
    [TestClass]
    public class KingFacing
    {
        [TestMethod]
        public void KingFacingMove() 
        {
            var pawn = Pawn.Of(Color.Red);
            var game = new ChessGame
            { 
                Board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
                {
                    { new Position(0, 4), King.Of(Color.Black) },
                    { new Position(4, 4), pawn },
                    { new Position(9, 4), King.Of(Color.Red) }
                })
            };
            
            try 
            {
                game.PerformTurn("e5d5");
                Assert.Fail("Move with King Facing was Valid");
            }
            catch(Exception ex) 
            {
            }
        }
    }
}
