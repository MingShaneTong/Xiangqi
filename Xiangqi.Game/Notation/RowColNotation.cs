using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;

namespace Xiangqi.Game.Notation
{
    public class RowColNotation : Notation
    {
        public override Move ToMove(Board board, Color color, string notation)
        {
            var oldRow = notation[0] - '0';
            var oldCol = notation[1] - '0';
            var newRow = notation[2] - '0';
            var newCol = notation[3] - '0';

            var oldPosition = new Position(oldRow, oldCol);
            var newPosition = new Position(newRow, newCol);

            var movingPiece = (Piece)board.GetPieceOn(oldPosition);
            var capturedPiece = (Piece)board.GetPieceOn(newPosition);

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
