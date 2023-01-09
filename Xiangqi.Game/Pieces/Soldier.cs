using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class Soldier : Piece, IPiece
    {
        public static Soldier Of(Color color)
        {
            return new Soldier() { Color = color };
        }
    }
}
