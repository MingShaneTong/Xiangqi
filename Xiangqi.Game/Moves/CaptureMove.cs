using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Pieces;

namespace Xiangqi.Game.Moves
{
    public class CaptureMove : Move
    {
        public Piece PieceCaptured { get; init; }

        public override bool IsValid(Board board)
        {
            if (Piece == null || PieceCaptured == null || OldPosition == null || NewPosition == null || Color == null) { return false; }

            if (!OldPosition.IsValid() || !NewPosition.IsValid()) { return false; }
            if (OldPosition == NewPosition) { return false; }
            if (board.GetPieceOn(OldPosition) != Piece) { return false; }
            if (board.GetPieceOn(NewPosition) != PieceCaptured) { return false; }
            if (Piece.Color != Color) { return false; }
            if (Piece.Color == PieceCaptured.Color) { return false; }

            return Piece.IsValidMove(board, OldPosition, NewPosition, PieceCaptured);
        }

        public override void Apply(Board board)
        {
            if (IsValid(board)) { throw new Exception("Capture Move Not Valid"); }
            board.SetPieceOn(OldPosition, null);
            board.SetPieceOn(NewPosition, Piece);
        }
    }
}
