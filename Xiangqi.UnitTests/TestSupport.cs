using Xiangqi.Game;
using Xiangqi.Game.Notation;

namespace Xiangqi.UnitTests
{
    public class TestSupport
    {
        public static bool MoveIsValid(string givenBoard, Color whenColor, string whenMove)
        {
            var notation = new BasicAlgebraicNotation();
            var board = BoardCreator.BuildBoard(givenBoard);
            var move = notation.ToMove(board, whenColor, whenMove);
            return move.IsValid(board);
        }
    }
}
