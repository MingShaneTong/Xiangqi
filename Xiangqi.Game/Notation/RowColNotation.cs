using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;

namespace Xiangqi.Game.Notation
{
    public class RowColNotation : Notation
    {
        public override Move ToMove(Board board, Color color, string notation)
        {
            int oldRow = notation[0] - '0';
            int oldCol = notation[1] - '0';
            int newRow = notation[2] - '0';
            int newCol = notation[3] - '0';

            Position oldPosition = new Position(oldRow, oldCol);
            Position newPosition = new Position(newRow, newCol);

            Piece movingPiece = (Piece)board.GetPieceOn(oldPosition);
            Piece capturedPiece = (Piece)board.GetPieceOn(newPosition);

            return new Move
            {
                OldPosition = oldPosition,
                NewPosition = newPosition,
                Piece = movingPiece,
                PieceCaptured = capturedPiece,
                Color = color
            };
        }
    }
}
