using Xiangqi.Game.Moves;

namespace Xiangqi.Game.Notation
{
    public interface INotation
    {
        public Move ToMove(Board board, Color color, string notation);
    }
}
