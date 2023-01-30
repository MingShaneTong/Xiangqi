using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game
{
    public static class BoardStringConstructor
    {
        public static string Construct(Board board) 
        {
            StringBuilder boardString = new StringBuilder();
            IEnumerable<KeyValuePair<Position, Pieces.Piece>> pieces = board.GetPiecesWhere(p => p != null);
            foreach (KeyValuePair<Position, Pieces.Piece> p in pieces)
            {
                Position pos = p.Key;
                Pieces.Piece piece = p.Value;
                boardString.AppendLine(piece.Color.ToString().ToLower() + " " + piece.PieceName());
                boardString.AppendLine(String.Format("r{0}c{1}", pos.Row, pos.Col));
                boardString.AppendLine("=====");
            }
            return boardString.ToString();
        }
    }
}
