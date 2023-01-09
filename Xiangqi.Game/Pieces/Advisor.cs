using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class Advisor : Piece, IPiece
    {
        public override string ToString()
        {
            switch (Color) 
            {
                case Color.Black:
                    return "士";
                case Color.Red:
                    return "仕";
                default:
                    throw new ArgumentException("The Piece Color is not valid");
            }
        }

        public static Advisor Of(Color color)
        {
            return new Advisor() { Color = color };
        }
    }
}
