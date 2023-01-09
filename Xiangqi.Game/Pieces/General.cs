using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class General : Piece, IPiece
    {
        public static General Of(Color color)
        {
            return new General() { Color = color };
        }
    }
}
