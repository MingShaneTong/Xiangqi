using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class Horse : Piece, IPiece
    {
        public static Horse Of(Color color)
        {
            return new Horse() { Color = color };
        }
    }
}
