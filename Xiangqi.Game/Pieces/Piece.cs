using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public abstract class Piece : IPiece
    {
        public Color Color { get; init; }
        public abstract String PieceName();

        public abstract bool IsValidMove(Board board, Position oldPosition, Position newPosition, IPiece? pieceCaptured = null);
    }
}
