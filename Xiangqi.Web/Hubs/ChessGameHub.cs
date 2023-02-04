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
            var game = GameManager.GetGame(gameId);

            // TODO: If game not found, respond error

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
            var gameMsg = new GameMessage()
            {
                GameId = game.GameId.ToString(),
                Turn = game.ChessGame.Turn.ToString(),
                Board = game.ChessGame.Board
                    .GetPiecesWhere(p => p != null)
                    .Select(p =>
                    {
                        var position = p.Key;
                        var piece = p.Value;

                        return new PieceMessage()
                        {
                            Piece = piece.PieceName(),
                            Color = piece.Color.ToString(),
                            Row = position.Row,
                            Col = position.Col
                        };
                    })
            };

            gameMsg.Player = Color.Red.ToString();
            var redJson = JsonConvert.SerializeObject(gameMsg);
            Clients.Clients(game.RedPlayerConnection).SendAsync("GameState", redJson);
            gameMsg.Player = Color.Black.ToString();
            var blackJson = JsonConvert.SerializeObject(gameMsg);
            Clients.Clients(game.BlackPlayerConnection).SendAsync("GameState", blackJson);
        }

        public void GameMove(string msg)
        {
            var moveMsg = JsonConvert.DeserializeObject<MoveMessage>(msg);
            var gameId = new Guid(moveMsg.GameId);
            var game = GameManager.GetGame(gameId);

            // TODO: If game not found, respond error

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
