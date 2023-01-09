using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class Elephant : Piece, IPiece
    {
        public static Elephant Of(Color color)
        {
            return new Elephant() { Color = color };
        }
    }
}
