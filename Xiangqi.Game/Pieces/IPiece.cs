using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public interface IPiece
    {
        public bool IsValidMove(Board board, Position oldPosition, Position newPosition);
        public bool IsValidMove(Board board, Position oldPosition, Position newPosition, IPiece pieceCaptured);
    }
}
