using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class Elephant : Piece
    {
        public override bool IsValidMove(Board board, Position oldPosition, Position newPosition)
        {
            // must be on same side
            if (Board.GetPositionSide(oldPosition) != Color) { return false; }
            if (Board.GetPositionSide(newPosition) != Color) { return false; }

            // must be 2 square diagonal
            int rowDiff = Math.Abs(oldPosition.Row - newPosition.Row);
            int colDiff = Math.Abs(oldPosition.Col - newPosition.Col);
            if (rowDiff != 2 || colDiff != 2) { return false; }

            // no obstruction
            return !board.GetDiagonalPiecesBetween(oldPosition, newPosition).Any();
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
