using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class Cannon : Piece, IPiece
    {
        public static Cannon Of(Color color)
        {
            return new Cannon() { Color = color };
        }
    }
}
