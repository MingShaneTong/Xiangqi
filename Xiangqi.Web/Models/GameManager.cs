using System.Linq;

namespace Xiangqi.Web.Models
{
    public class GameManager
    {
        public Game? PendingGame { get; set; }
        public IDictionary<Guid, Game> Games { get; init; }

        public GameManager()
        { 
            Games = new Dictionary<Guid, Game>();
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
                var game = PendingGame;
                game.BlackPlayerConnection = connection;
                Games.Add(game.GameId, game);

                PendingGame = null;
                return game;
            }
        }

        public Game GetGame(Guid gameId)
        {
            return Games[gameId];
        }

        public Dictionary<Guid, Game>? EndGameWithUser(string connection)
        {
            if (PendingGame != null && PendingGame.RedPlayerConnection == connection)
            {
                PendingGame = null;
                return null;
            }

            var games = Games
                .Where(i => IsPlayer(i.Value, connection))
                .ToDictionary(i => i.Key, i => i.Value);

			foreach (var g in games)
			{
				Games.Remove(g.Key);
			}

			return games;
        }

        private bool IsPlayer(Game game, string connection)
        { 
            return 
                game.BlackPlayerConnection == connection || 
                game.RedPlayerConnection == connection;
        }

	}
}
