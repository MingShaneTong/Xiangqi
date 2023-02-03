using Xiangqi.Game;

namespace Xiangqi.Web.Models.Json
{
    public class PieceJson
    { 
        public string Piece { get; set; }
        public string Color { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }

    public class GameJson
    {
        public string GameId { get; set; }
        public string Turn { get; set; }
        public string Player { get; set; }
        public IEnumerable<PieceJson> Board { get; set; }
    }
}
