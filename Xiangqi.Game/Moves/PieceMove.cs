using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Pieces;

namespace Xiangqi.Game.Moves
{
    public class PieceMove : Move
    {
        public override bool IsValid(Board board)
        {
            if (Piece == null || OldPosition == null || NewPosition == null || Color == null) { return false; }

            if (!OldPosition.IsValid() || !NewPosition.IsValid()) { return false; }
            if (OldPosition == NewPosition) { return false; }
            if (board.GetPieceOn(OldPosition) != Piece) { return false; }
            if (board.GetPieceOn(NewPosition) != null) { return false; }
            if (Piece.Color != Color) { return false; }

            return Piece.IsValidMove(board, OldPosition, NewPosition);
        }

        public override void Apply(Board board)
        {
            board.SetPieceOn(OldPosition, null);
            board.SetPieceOn(NewPosition, Piece);
        }
    }
}
