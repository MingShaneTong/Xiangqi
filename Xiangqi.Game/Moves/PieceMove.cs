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
        public Position OldPosition { get; init; }
        public Position NewPosition { get; init; }
        public IPiece Piece { get; init; }

        public override bool IsValid(Board board)
        {
            return Piece.IsValidMove(board, OldPosition, NewPosition);
        }

        public override void Apply(Board board)
        {
            board.SetPieceOn(OldPosition, null);
            board.SetPieceOn(NewPosition, Piece);
        }
    }
}
