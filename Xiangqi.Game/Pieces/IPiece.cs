using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public interface IPiece
    {
        bool IsValidMove(Board board, Position oldPosition, Position newPosition, IPiece? pieceCaptured = null);
    }
}
