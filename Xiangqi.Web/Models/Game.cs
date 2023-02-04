using Xiangqi.Game;

namespace Xiangqi.Web.Models
{
    public class Game
    {
        public Guid GameId { get; set; }
        public ChessGame ChessGame { get; set; }

        public string RedPlayerConnection { get; set; }
        public bool RedAck { get; set; }
        public string BlackPlayerConnection { get; set; }
        public bool BlackAck { get; set; }
        public bool SentGameStart { get; set; }

        public Game()
        { 
            GameId = Guid.NewGuid();
            ChessGame = new ChessGame();
            SentGameStart = false;
        }

        public bool IsPlayer(string connectionId)
        {
            return GetPlayerColor(connectionId) != null;
        }

        public Color? GetPlayerColor(string connectionId)
        {
            if (RedPlayerConnection == connectionId) { return Color.Red; }
            if (BlackPlayerConnection == connectionId) { return Color.Black; }
            return null;
        }
    }
}
