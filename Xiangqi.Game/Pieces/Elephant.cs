using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class Elephant : Piece
    {
        public override bool IsValidMove(Board board, Position oldPosition, Position newPosition, IPiece? pieceCaptured = null)
        {
            // must be on same side
            if (Board.GetPositionSide(oldPosition) != Color) { return false; }
            if (Board.GetPositionSide(newPosition) != Color) { return false; }

            // must be 2 square diagonal
            var rowDiff = Math.Abs(oldPosition.Row - newPosition.Row);
            var colDiff = Math.Abs(oldPosition.Col - newPosition.Col);
            if (rowDiff != 2 || colDiff != 2) { return false; }

            // no obstruction
            return !board.GetDiagonalPiecesBetween(oldPosition, newPosition).Any();
        }

        public override string PieceName()
        {
            return "Elephant";
        }

        public override string ToString()
        {
            switch (Color)
            {
                case Color.Red:
                    return "E";
                case Color.Black:
                    return "e";
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
