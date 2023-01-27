namespace Xiangqi.Web.Models
{
    public class GameManager
    {
        public Game? PendingGame { get; set; }
        public ISet<Game> Games { get; init; }

        public GameManager()
        { 
            Games = new HashSet<Game>();
        }

        public Game? MatchConnection(string connection)
        {
            if (PendingGame == null)
            {
                PendingGame = new Game()
                {
                    RedPlayerConnection = connection
                };
                return null;
            }
            else
            {
                Game game = PendingGame;
                PendingGame.BlackPlayerConnection = connection;
                PendingGame = null;
                return game;
            }
        }
    }
}
