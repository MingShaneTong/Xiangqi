using Xiangqi.Game.Moves;

namespace Xiangqi.Game.Notation
{
    public abstract class Notation : INotation
    {
        public abstract Move ToMove(Board board, Color color, string notation);
    }
}
