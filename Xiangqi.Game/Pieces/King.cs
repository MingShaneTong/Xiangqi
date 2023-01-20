using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class King : Piece
    {
        public override bool IsValidMove(Board board, Position oldPosition, Position newPosition, IPiece? pieceCaptured = null)
        {
            if (!Board.InCastle(Color, newPosition) || !Board.InCastle(Color, newPosition)) { return false; }
            if (oldPosition.Row == newPosition.Row)
            {
                return Math.Abs(newPosition.Col - oldPosition.Col) == 1;
            }
            if (oldPosition.Col == newPosition.Col)
            {
                return Math.Abs(newPosition.Row - oldPosition.Row) == 1;
            }

            return false;
        }

        public override string ToString()
        {
            switch (Color)
            {
                case Color.Red:
                    return "K";
                case Color.Black:
                    return "k";
                default:
                    throw new ArgumentException("The Piece Color is not valid");
            }
        }

        public static King Of(Color color)
        {
            return new King() { Color = color };
        }
    }
}
