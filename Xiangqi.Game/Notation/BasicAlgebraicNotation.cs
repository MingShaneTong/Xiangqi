using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;

namespace Xiangqi.Game.Notation
{
    public class BasicAlgebraicNotation : Notation
    {
        public override Move ToMove(Board board, Color color, string notation)
        {
            int oldCol = notation[0] - 'a';
            int oldRow = 9 - (notation[1] - '0');
            int newCol = notation[2] - 'a';
            int newRow = 9 - (notation[3] - '0');

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
