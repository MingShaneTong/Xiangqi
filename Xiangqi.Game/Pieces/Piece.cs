using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public abstract class Piece : IPiece
    {
        private Color _color;
        public Color Color
        {
            get { return _color; }
            init { _color = value; }
        }

        public abstract bool IsValidMove(Board board, Position oldPosition, Position newPosition, IPiece? pieceCaptured = null);
        //public abstract bool Advance(Board board, File oldFile, File newFile);
        //public abstract bool CanAdvance(Board board, File oldFile, File newFile);
    }
}
