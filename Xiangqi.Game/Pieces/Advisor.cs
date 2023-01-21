using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class Advisor : Piece
    {
        public override bool IsValidMove(Board board, Position oldPosition, Position newPosition, IPiece? pieceCaptured = null)
        {
            if (!Board.InCastle(Color, newPosition) || !Board.InCastle(Color, newPosition)) { return false; }
            return 
                Math.Abs(newPosition.Col - oldPosition.Col) == 1 && 
                Math.Abs(newPosition.Row - oldPosition.Row) == 1;
        }

        public override string ToString()
        {
            switch (Color)
            {
                case Color.Red:
                    return "A";
                case Color.Black:
                    return "a";
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
