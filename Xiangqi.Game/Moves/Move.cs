using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Pieces;

namespace Xiangqi.Game.Moves
{
    public abstract class Move : IMove
    {
        public Position OldPosition { get; init; }
        public Position NewPosition { get; init; }
        public Piece Piece { get; init; }
        public Color Color { get; init; }

        public abstract bool IsValid(Board board);
        public abstract void Apply(Board board);
    }
}
