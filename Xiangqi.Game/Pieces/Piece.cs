namespace Xiangqi.Game.Pieces
{
    public abstract class Piece : IPiece
    {
        public Color Color { get; init; }
        public abstract string PieceName();
        public abstract bool IsValidMove(Board board, Position oldPosition, Position newPosition, IPiece? pieceCaptured = null);
    }
}
