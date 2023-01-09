using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class General : Piece, IPiece
    {
        public override string ToString()
        {
            switch (Color)
            {
                case Color.Black:
                    return "将";
                case Color.Red:
                    return "帥";
                default:
                    throw new ArgumentException("The Piece Color is not valid");
            }
        }

        public static General Of(Color color)
        {
            return new General() { Color = color };
        }
    }
}
