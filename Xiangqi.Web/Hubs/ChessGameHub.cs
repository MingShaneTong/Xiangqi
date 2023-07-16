using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Xiangqi.Game;
using Xiangqi.Web.Models;
using Xiangqi.Web.Models.Messages;

namespace Xiangqi.Web.Hubs
{
    public class ChessGameHub : Hub
    {
        public static readonly GameManager GameManager;
        static ChessGameHub()
        {
            GameManager = new GameManager();
        }

		public override Task OnDisconnectedAsync(Exception? exception)
		{
            var games = GameManager.EndGameWithUser(Context.ConnectionId);
            if (games != null)
            {
			    foreach (var g in games)
			    {
			        // tell both players game has ended
			        Clients.Clients(g.Value.RedPlayerConnection)
				        .SendAsync(
						    g.Value.RedPlayerConnection == Context.ConnectionId ?
                                "PlayerDisconnected" : "OpponentDisconnected", 
                            g.Key.ToString());
			        Clients.Clients(g.Value.BlackPlayerConnection)
				        .SendAsync(
							g.Value.BlackPlayerConnection == Context.ConnectionId ?
								"PlayerDisconnected" : "OpponentDisconnected",
							g.Key.ToString());
			    }

            }
			return base.OnDisconnectedAsync(exception);
		}

		public void JoinGame()
        {
            var gameJoined = GameManager.MatchConnection(Context.ConnectionId);
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
            var gameId = new Guid(message);
            var game = GetGame(gameId);
            if (game == null) { return; }

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
                SendGameState(game);
            }
        }

        private void SendGameState(Models.Game game)
        {
            var gameMsg = GameMessage.Of(game);

            gameMsg.Player = Color.Red.ToString();
            var redJson = JsonConvert.SerializeObject(gameMsg);
            Clients.Clients(game.RedPlayerConnection).SendAsync("GameState", redJson);

            gameMsg.Player = Color.Black.ToString();
            var blackJson = JsonConvert.SerializeObject(gameMsg);
            Clients.Clients(game.BlackPlayerConnection).SendAsync("GameState", blackJson);
        }

        private Models.Game? GetGame(Guid gameId) 
        {
            var game = GameManager.GetGame(gameId);
            if (game == null) 
            {
                Clients.Caller.SendAsync("GameNotFound");
                return null;
            }
            return game;
        }

        public void GameMove(string msg)
        {
            var moveMsg = JsonConvert.DeserializeObject<MoveMessage>(msg);
            var gameId = new Guid(moveMsg.GameId);
            var game = GetGame(gameId);
            if(game == null) { return; }

            // player color
            var playerColor = game.GetPlayerColor(Context.ConnectionId);
            if (playerColor == null) { return; }
            if (playerColor != game.ChessGame.Turn) { return; }

            var oldPos = moveMsg.OldPosition;
            var newPos = moveMsg.NewPosition;

            try
            {
                game.ChessGame.PerformTurn($"{oldPos.Row}{oldPos.Col}{newPos.Row}{newPos.Col}");
                SendGameState(game);
            }
            catch
            { 
            }
        }
    }
}
