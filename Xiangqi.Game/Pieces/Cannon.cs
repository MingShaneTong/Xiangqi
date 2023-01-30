using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class Cannon : Piece
    {
        public override bool IsValidMove(Board board, Position oldPosition, Position newPosition, IPiece? pieceCaptured = null)
        {
            if (oldPosition.Row == newPosition.Row)
            {
                IList<IPiece> piecesBlocking = board.GetHorizontalPiecesBetween(oldPosition, newPosition);
                if (pieceCaptured != null) 
                { 
                    return piecesBlocking.Count() == 1; 
                }
                return !piecesBlocking.Any();
            }
            if (oldPosition.Col == newPosition.Col)
            {
                IList<IPiece> piecesBlocking = board.GetVerticalPiecesBetween(oldPosition, newPosition);
                if (pieceCaptured != null)
                {
                    return piecesBlocking.Count() == 1;
                }
                return !piecesBlocking.Any();
            }

            return false;
        }

        public override string PieceName()
        {
            return "Cannon";
        }

        public override string ToString()
        {
            switch (Color)
            {
                case Color.Red:
                    return "C";
                case Color.Black:
                    return "c";
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
