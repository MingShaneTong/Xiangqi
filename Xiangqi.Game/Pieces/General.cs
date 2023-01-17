using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class General : Piece
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
