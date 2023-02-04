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
            var row = p1.Row;
            var piecesBetween = new List<IPiece>();
            if (p1.Col > p2.Col) { (p1, p2) = (p2, p1); }
            for (var col = p1.Col + 1; col < p2.Col; col++)
            {
                var piece = Pieces[row, col];
                if (piece == null) { continue; }
                piecesBetween.Add(piece);
            }
            return piecesBetween;
        }

        public IList<IPiece> GetVerticalPiecesBetween(Position p1, Position p2)
        {
            if (p1.Col != p2.Col) { throw new Exception("Positions are not on the same column"); }
            var col = p1.Col;
            var piecesBetween = new List<IPiece>();
            if (p1.Row > p2.Row) { (p1, p2) = (p2, p1); }
            for (var row = p1.Row + 1; row < p2.Row; row++)
            {
                var piece = Pieces[row, col];
                if (piece == null) { continue; }
                piecesBetween.Add(piece);
            }
            return piecesBetween;
        }

        public IList<IPiece> GetDiagonalPiecesBetween(Position p1, Position p2)
        {
            var rowDiff = Math.Abs(p1.Row - p2.Row);
            var colDiff = Math.Abs(p1.Col - p2.Col);
            if (rowDiff != colDiff) { throw new Exception("Positions are not diagonal from each other"); }

            var piecesBetween = new List<IPiece>();
            if (p1.Row > p2.Row) { (p1, p2) = (p2, p1); }
            var dir = Math.Sign(p2.Col - p1.Col);

            for (var i = 1; i < rowDiff; i++)
            {
                var row = p1.Row + i;
                var col = p1.Col + dir * i;
                var piece = Pieces[row, col];
                if (piece == null) { continue; }
                piecesBetween.Add(piece);
            }
            return piecesBetween;
        }

        public IEnumerable<KeyValuePair<Position, Piece>> GetPiecesWhere(Func<IPiece, bool> condition)
        {
           var results = new List<KeyValuePair<Position, Piece>>(); 
            for (var i = 0; i < Pieces.GetLength(0); i++)
            {
                for (var j = 0; j < Pieces.GetLength(1); j++)
                {
                    if (condition(Pieces[i, j]))
                    {
                        var position = new Position(i, j);
                        var piece = Pieces[i, j] as Piece;
                        results.Add(new KeyValuePair<Position, Piece>(position, piece));
                    }
                }
            }
            return results;
        }

        public bool KingsAreFacing()
        {
            var kings = GetPiecesWhere((IPiece piece) => piece is King);
            if (kings.Count() != 2) { throw new Exception("Expected: 2 Kings"); }
            var kingsArray = kings.ToArray();
            
            var king1 = kingsArray[0];
            var king2 = kingsArray[1];

            if (king1.Key.Col == king2.Key.Col)
            {
                return !GetVerticalPiecesBetween(king1.Key, king2.Key).Any();
            }
            return false;
        }

        public bool PositionIsVulnerable(Position position, Color color, Piece captured)
        {
            for (var row = 0; row < Pieces.GetLength(0); row++)
            {
                for (var col = 0; col < Pieces.GetLength(1); col++)
                {
                    var oldPosition = new Position(row, col);
                    var piece = (Piece)GetPieceOn(oldPosition);

                    if (piece == null) { continue; }
                    if (piece.Color == color) { continue; }
                    if (!piece.IsValidMove(this, oldPosition, position, captured)) { continue; }
                    return true;
                }
            }
            return false;
        }

        public bool KingInCheck(Color color)
        {
            var kingSearch = GetPiecesWhere(
                (IPiece piece) => piece is King && ((Piece) piece).Color == color
            );
            if (kingSearch.Count() != 1) { throw new Exception("Expected 1 King"); }
            var king = kingSearch.ToArray()[0];
            return PositionIsVulnerable(king.Key, color, king.Value);
        }

        public bool IsInCheckmate(Color color)
        {
            if (!KingInCheck(color)) { return false; }
            return ValidMovesAvailable(color);
        }

        public bool IsInStalemate(Color color)
        {
            if (KingInCheck(color)) { return false; }
            return ValidMovesAvailable(color);
        }

        public bool ValidMovesAvailable(Color color)
        {
            // check if any moves do not result in check
            var pieceSearch = GetPiecesWhere(
                (IPiece piece) => piece != null && ((Piece)piece).Color == color
            );
            foreach (var positionPiecePair in pieceSearch)
            {
                var position = positionPiecePair.Key;
                var piece = positionPiecePair.Value;

                for (var row = 0; row < Pieces.GetLength(0); row++)
                {
                    for (var col = 0; col < Pieces.GetLength(1); col++)
                    {
                        var newPosition = new Position(row, col);
                        var captured = (Piece)GetPieceOn(newPosition);
                        if (!piece.IsValidMove(this, position, newPosition, captured)) { continue; }
                        return true;
                    }
                }
            }
            return false;
        }

        public override string ToString()
        {
            var rowString = new string[Rows];
            for (var i = 0; i < Rows; i++)
            {
                var colString = new string[Cols];
                for (var j = 0; j < Cols; j++)
                {
                    var p = Pieces[i,j];
                    colString[j] = p != null ? p.ToString() : " ";
                }
                rowString[i] = string.Join("|", colString);
            }
            return string.Join("\n", rowString);
        }
    }
}
