using Microsoft.AspNetCore.SignalR;
using Xiangqi.Web.Models;

namespace Xiangqi.Web.Hubs
{
    public class ChessGameHub : Hub
    {
        public static readonly GameManager GameManager;
        static ChessGameHub() 
        { 
            GameManager = new GameManager();
        }

        public void JoinGame()
        {
            Models.Game? gameJoined = GameManager.MatchConnection(Context.ConnectionId);
            if (gameJoined == null)
            {
                // tell client game to wait for game
                Clients.Caller.SendAsync("AwaitingOpponent");
            }
            else 
            {
                // tell both players to respond with game ack
                Clients.Clients(gameJoined.RedPlayerConnection)
                    .SendAsync("GameCreatedSyn", gameJoined.GameId.ToString());
                Clients.Clients(gameJoined.BlackPlayerConnection)
                    .SendAsync("GameCreatedSyn", gameJoined.GameId.ToString());
            }
        }

        public void GameCreatedAck(string message)
        {
            Guid gameId = new Guid(message);
            Models.Game game = GameManager.GetGame(gameId);

            // trigger ack
            if (game.RedPlayerConnection == Context.ConnectionId)
            {
                game.RedAck = true;
            }
            else if (game.BlackPlayerConnection == Context.ConnectionId)
            { 
                game.BlackAck = true;
            }

            // trigger game start
            if (game.RedAck && game.BlackAck && !game.SentGameStart)
            {
                game.SentGameStart = true;
                Clients.Clients(game.RedPlayerConnection)
                    .SendAsync("GamePlay", game.ChessGame.Board.ToString());
                Clients.Clients(game.BlackPlayerConnection)
                    .SendAsync("GameWait", game.ChessGame.Board.ToString());
            }
        }
    }
}
