using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using Xiangqi.Game;
using Xiangqi.Game.Pieces;
using Xiangqi.Web.Models;
using Xiangqi.Web.Models.Json;

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
            var game = GameManager.GetGame(gameId);

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

                var json = new GameJson()
                {
                    GameId = game.GameId.ToString(),
                    Turn = game.ChessGame.Turn.ToString(),
                    Board = game.ChessGame.Board
                        .GetPiecesWhere(p => p != null)
                        .Select(p => {
                            var position = p.Key;
                            var piece = p.Value;

                            return new PieceJson()
                            {
                                Piece = piece.PieceName(),
                                Color = piece.Color.ToString(),
                                Row = position.Row,
                                Col = position.Col
                            };
                        })
                };

                var opt = new JsonSerializerOptions() { WriteIndented = true };

                json.Player = Color.Red.ToString();
                var redJson = JsonSerializer.Serialize(json, opt);
                Clients.Clients(game.RedPlayerConnection).SendAsync("GamePlay", redJson);
                json.Player = Color.Black.ToString();
                var blackJson = JsonSerializer.Serialize(json, opt);
                Clients.Clients(game.BlackPlayerConnection).SendAsync("GameWait", blackJson);
            }
        }
    }
}
