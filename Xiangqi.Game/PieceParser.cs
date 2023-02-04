using Xiangqi.Game.Pieces;

namespace Xiangqi.Game
{
    public class PieceParser
    {
        public static Piece ToPiece(string pieceString)
        {
            var color = pieceString == pieceString.ToUpper() ? Color.Red : Color.Black;
            switch (pieceString.ToUpper())
            {
                case "K":
                    return King.Of(color);
                case "A":
                    return Advisor.Of(color);
                case "E":
                    return Elephant.Of(color);
                case "H":
                    return Horse.Of(color);
                case "R":
                    return Rook.Of(color);
                case "C":
                    return Cannon.Of(color);
                case "P":
                    return Pawn.Of(color);
                default:
                    return null;
            }
        }
    }
}
