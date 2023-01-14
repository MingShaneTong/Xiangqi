using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Pieces;

namespace Xiangqi.Game
{
    public class Board
    {
        public const int Rows = 10;
        public const int Cols = 9;
        public const int BlackRiver = 4;
        public const int RedRiver = 5;

        public IPiece[,] Pieces { get; init; }

        public IPiece GetPieceOn(Position position)
        {
            if (!position.IsValid()) { return null; }
            return Pieces[position.Row, position.Col];
        }

        public void SetPieceOn(Position position, IPiece piece)
        {
            Pieces[position.Row, position.Col] = piece;
        }

        public static Color GetPositionSide(Position position)
        {
            if (position.Row >= RedRiver) 
            { 
                return Color.Red; 
            }
            return Color.Black;
        }

        public override string ToString()
        {
            string[] rowString = new string[Rows];
            for (int i = 0; i < Rows; i++)
            {
                string[] colString = new string[Cols];
                for (int j = 0; j < Cols; j++)
                {
                    IPiece p = Pieces[i,j];
                    colString[j] = p != null ? p.ToString() : "。";
                }
                rowString[i] = string.Join("|", colString);
            }
            return string.Join("\n", rowString);
        }
    }
}
