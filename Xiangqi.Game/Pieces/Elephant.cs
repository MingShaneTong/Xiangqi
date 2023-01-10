using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class Elephant : Piece
    {
        public override string ToString()
        {
            switch (Color)
            {
                case Color.Black:
                    return "象";
                case Color.Red:
                    return "相";
                default:
                    throw new ArgumentException("The Piece Color is not valid");
            }
        }
        public static Elephant Of(Color color)
        {
            return new Elephant() { Color = color };
        }
    }
}
