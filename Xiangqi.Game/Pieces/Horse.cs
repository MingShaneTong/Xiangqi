using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class Horse : Piece
    {
        public override bool IsValidMove(Board board, Position oldPosition, Position newPosition, IPiece? pieceCaptured = null)
        {
            int rowDiff = Math.Abs(oldPosition.Row - newPosition.Row);
            int colDiff = Math.Abs(oldPosition.Col - newPosition.Col);
            
            if (rowDiff == 2 && colDiff == 1) 
            {
                Position checkPosition = new Position(newPosition.Row, oldPosition.Col);
                return !board.GetVerticalPiecesBetween(oldPosition, checkPosition).Any();
            }

            if (rowDiff == 1 && colDiff == 2)
            {
                Position checkPosition = new Position(oldPosition.Row, newPosition.Col);
                return !board.GetHorizontalPiecesBetween(oldPosition, checkPosition).Any();
            }

            return false;
        }

        public override string ToString()
        {
            switch (Color)
            {
                case Color.Black:
                    return "馬";
                case Color.Red:
                    return "傌";
                default:
                    throw new ArgumentException("The Piece Color is not valid");
            }
        }

        public static Horse Of(Color color)
        {
            return new Horse() { Color = color };
        }
    }
}
