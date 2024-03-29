﻿namespace Xiangqi.Game.Pieces
{
    public class Rook : Piece
    {
        public override bool IsValidMove(Board board, Position oldPosition, Position newPosition, IPiece? pieceCaptured = null)
        {
            if (oldPosition.Row == newPosition.Row)
            {
                var piecesBlocking = board.GetHorizontalPiecesBetween(oldPosition, newPosition);
                return !piecesBlocking.Any();
            }
            if (oldPosition.Col == newPosition.Col)
            {
                var piecesBlocking = board.GetVerticalPiecesBetween(oldPosition, newPosition);
                return !piecesBlocking.Any();
            }

            return false;
        }

        public override string PieceName()
        {
            return "Rook";
        }

        public override string ToString()
        {
            switch (Color)
            {
                case Color.Red:
                    return "R";
                case Color.Black:
                    return "r";
                default:
                    throw new ArgumentException("The Piece Color is not valid");
            }
        }

        public static Rook Of(Color color)
        {
            return new Rook() { Color = color };
        }
    }
}
