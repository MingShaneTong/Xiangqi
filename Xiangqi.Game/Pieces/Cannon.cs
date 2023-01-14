using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class Cannon : Piece
    {
        public override bool IsValidMove(Board board, Position oldPosition, Position newPosition)
        {
            if (oldPosition.Row == newPosition.Row)
            {
                IList<IPiece> piecesBlocking = board.GetHorizontalPiecesBetween(oldPosition, newPosition);
                return !piecesBlocking.Any();
            }
            if (oldPosition.Col == newPosition.Col)
            {
                IList<IPiece> piecesBlocking = board.GetVerticalPiecesBetween(oldPosition, newPosition);
                return !piecesBlocking.Any();
            }

            return false;
        }

        public override bool IsValidMove(Board board, Position oldPosition, Position newPosition, IPiece pieceCaptured)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            switch (Color)
            {
                case Color.Black:
                    return "砲";
                case Color.Red:
                    return "炮";
                default:
                    throw new ArgumentException("The Piece Color is not valid");
            }
        }

        public static Cannon Of(Color color)
        {
            return new Cannon() { Color = color };
        }
    }
}
