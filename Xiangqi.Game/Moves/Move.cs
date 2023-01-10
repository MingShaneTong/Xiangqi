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

        public void Apply(Board board)
        {
            throw new NotImplementedException();
        }

        public bool IsValid(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
