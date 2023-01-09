using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class Advisor : Piece, IPiece
    {
        public static Advisor Of(Color color)
        {
            return new Advisor() { Color = color };
        }
    }
}
