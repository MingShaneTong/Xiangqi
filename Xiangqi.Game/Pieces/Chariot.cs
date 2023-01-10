using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class Chariot : Piece
    {
        public override string ToString()
        {
            switch (Color)
            {
                case Color.Black:
                    return "車";
                case Color.Red:
                    return "俥";
                default:
                    throw new ArgumentException("The Piece Color is not valid");
            }
        }

        public static Chariot Of(Color color)
        {
            return new Chariot() { Color = color };
        }
    }
}
