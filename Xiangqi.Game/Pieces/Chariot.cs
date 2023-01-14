using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class Chariot : Piece
    {
        public override bool IsValidMove(Board board, Position oldPosition, Position newPosition)
        {
            if (!oldPosition.IsValid() || !newPosition.IsValid()) { return false; }
            if (board.GetPieceOn(oldPosition) != this) { return false; }

            if (oldPosition == newPosition) { return false; }

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
