using Xiangqi.Game;

namespace Xiangqi.Web.Models.Messages
{
    public class PieceMessage
    {
        public string Piece { get; set; }
        public string Color { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }

    public class GameMessage
    {
        public string GameId { get; set; }
        public string Turn { get; set; }
        public string Player { get; set; }
        public IEnumerable<PieceMessage> Board { get; set; }
    }
}
