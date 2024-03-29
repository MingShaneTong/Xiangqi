﻿namespace Xiangqi.Game.Pieces
{
    public class Horse : Piece
    {
        public override bool IsValidMove(Board board, Position oldPosition, Position newPosition, IPiece? pieceCaptured = null)
        {
            var rowDiff = Math.Abs(oldPosition.Row - newPosition.Row);
            var colDiff = Math.Abs(oldPosition.Col - newPosition.Col);
            
            if (rowDiff == 2 && colDiff == 1) 
            {
                var checkPosition = new Position(newPosition.Row, oldPosition.Col);
                return !board.GetVerticalPiecesBetween(oldPosition, checkPosition).Any();
            }

            if (rowDiff == 1 && colDiff == 2)
            {
                var checkPosition = new Position(oldPosition.Row, newPosition.Col);
                return !board.GetHorizontalPiecesBetween(oldPosition, checkPosition).Any();
            }

            return false;
        }

        public override string PieceName()
        {
            return "Horse";
        }

        public override string ToString()
        {
            switch (Color)
            {
                case Color.Red:
                    return "H";
                case Color.Black:
                    return "h";
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
