using System;
using System.Collections;
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

        public const int CastleMinCol = 3;
        public const int CastleMaxCol = 5;
        public const int CastleRedMinRow = 7;
        public const int CastleBlackMaxRow = 2;

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

        public static bool InCastle(Color castleColor, Position position)
        {
            if(position.Col < CastleMinCol || CastleMaxCol < position.Col) { return false;  }
            switch (castleColor) { 
                case Color.Black:
                    return 0 <= position.Row && position.Row <= CastleBlackMaxRow;
                case Color.Red:
                    return CastleRedMinRow <= position.Row && position.Row < Rows;
            }
            return false;
        }

        public IList<IPiece> GetHorizontalPiecesBetween(Position p1, Position p2)
        {
            if (p1.Row != p2.Row) { throw new Exception("Positions are not on the same row"); }
            int row = p1.Row;
            IList<IPiece> piecesBetween = new List<IPiece>();
            if (p1.Col > p2.Col) { (p1, p2) = (p2, p1); }
            for (int col = p1.Col + 1; col < p2.Col; col++)
            {
                IPiece piece = Pieces[row, col];
                if (piece == null) { continue; }
                piecesBetween.Add(piece);
            }
            return piecesBetween;
        }

        public IList<IPiece> GetVerticalPiecesBetween(Position p1, Position p2)
        {
            if (p1.Col != p2.Col) { throw new Exception("Positions are not on the same column"); }
            int col = p1.Col;
            IList<IPiece> piecesBetween = new List<IPiece>();
            if (p1.Row > p2.Row) { (p1, p2) = (p2, p1); }
            for (int row = p1.Row + 1; row < p2.Row; row++)
            {
                IPiece piece = Pieces[row, col];
                if (piece == null) { continue; }
                piecesBetween.Add(piece);
            }
            return piecesBetween;
        }

        public IList<IPiece> GetDiagonalPiecesBetween(Position p1, Position p2)
        {
            int rowDiff = Math.Abs(p1.Row - p2.Row);
            int colDiff = Math.Abs(p1.Col - p2.Col);
            if (rowDiff != colDiff) { throw new Exception("Positions are not diagonal from each other"); }

            IList<IPiece> piecesBetween = new List<IPiece>();
            if (p1.Row > p2.Row) { (p1, p2) = (p2, p1); }
            int dir = Math.Sign(p2.Col - p1.Col);

            for (int i = 1; i < rowDiff; i++)
            {
                int row = p1.Row + i;
                int col = p1.Col + dir * i;
                IPiece piece = Pieces[row, col];
                if (piece == null) { continue; }
                piecesBetween.Add(piece);
            }
            return piecesBetween;
        }

        public IEnumerable<KeyValuePair<Position, Piece>> GetPiecesWhere(Func<IPiece, bool> condition)
        {
            IList<KeyValuePair<Position, Piece>> results = new List<KeyValuePair<Position, Piece>>(); 
            for (int i = 0; i < Pieces.GetLength(0); i++)
            {
                for (int j = 0; j < Pieces.GetLength(1); j++)
                {
                    if (condition(Pieces[i, j]))
                    {
                        Position position = new Position(i, j);
                        Piece piece = Pieces[i, j] as Piece;
                        results.Add(new KeyValuePair<Position, Piece>(position, piece));
                    }
                }
            }
            return results;
        }

        public bool KingsAreFacing()
        {
            IEnumerable<KeyValuePair<Position, Piece>> kings = GetPiecesWhere((IPiece piece) => piece is King);
            if (kings.Count() != 2) { throw new Exception("Expected: 2 Kings"); }
            KeyValuePair<Position, Piece>[] kingsArray = kings.ToArray();
            
            KeyValuePair<Position, Piece> king1 = kingsArray[0];
            KeyValuePair<Position, Piece> king2 = kingsArray[1];

            if (king1.Key.Col == king2.Key.Col)
            {
                return !GetVerticalPiecesBetween(king1.Key, king2.Key).Any();
            }
            return false;
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
