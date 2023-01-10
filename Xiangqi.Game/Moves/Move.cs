using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Moves
{
    public abstract class Move : IMove
    {
        private Color _color;
        public Color Color
        {
            get { return _color; }
            init { _color = value; }
        }

        public abstract bool IsValid(Board board);
        public abstract void Apply(Board board);
    }
}
