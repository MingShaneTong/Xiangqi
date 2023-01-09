using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class Chariot : Piece, IPiece
    {
        public static Chariot Of(Color color)
        {
            return new Chariot() { Color = color };
        }
    }
}
