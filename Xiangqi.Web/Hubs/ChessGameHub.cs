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
                    .SendAsync("GameCreatedSyn");
                Clients.Clients(gameJoined.BlackPlayerConnection)
                    .SendAsync("GameCreatedSyn");
            }
        }
    }
}
