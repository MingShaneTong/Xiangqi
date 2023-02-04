namespace Xiangqi.Game.Pieces
{
    public interface IPiece
    {
        bool IsValidMove(Board board, Position oldPosition, Position newPosition, IPiece? pieceCaptured = null);
    }
}
