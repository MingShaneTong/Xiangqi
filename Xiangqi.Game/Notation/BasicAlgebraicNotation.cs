using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;

namespace Xiangqi.Game.Notation
{
    public class BasicAlgebraicNotation : Notation
    {
        public override Move ToMove(Board board, Color color, string notation)
        {
            var oldCol = notation[0] - 'a';
            var oldRow = 9 - (notation[1] - '0');
            var newCol = notation[2] - 'a';
            var newRow = 9 - (notation[3] - '0');

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
