using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Pieces;

namespace Xiangqi.Game.Moves
{
    public class Move : IMove
    {
        public Position OldPosition { get; init; }
        public Position NewPosition { get; init; }
        public Piece Piece { get; init; }
        public Piece PieceCaptured { get; init; }
        public Color Color { get; init; }

        public bool IsValid(Board board)
        {
            if (Piece == null || OldPosition == null || NewPosition == null || Color == null) { return false; }

            if (!OldPosition.IsValid() || !NewPosition.IsValid()) { return false; }
            if (OldPosition == NewPosition) { return false; }
            if (board.GetPieceOn(OldPosition) != Piece) { return false; }
            if (board.GetPieceOn(NewPosition) != PieceCaptured) { return false; }
            if (Piece.Color != Color) { return false; }

            return Piece.IsValidMove(board, OldPosition, NewPosition, PieceCaptured);
        }

        public void Apply(Board board)
        {
            if (!IsValid(board)) { throw new Exception("Move Not Valid"); }
            board.SetPieceOn(NewPosition, Piece);
            board.SetPieceOn(OldPosition, null);
        }
    }
}
