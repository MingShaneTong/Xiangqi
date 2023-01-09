using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public abstract class Piece
    {
        private Color _color;
        public Color Color 
        {
            get { return _color; }
            init { _color = value; }
        }
    }
}
