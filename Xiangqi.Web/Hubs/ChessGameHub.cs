using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using Xiangqi.Game;
using Xiangqi.Game.Pieces;
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
                Clients.Clients(game.RedPlayerConnection).SendAsync("GamePlay", gameMsg);
                gameMsg.Player = Color.Black.ToString();
                Clients.Clients(game.BlackPlayerConnection).SendAsync("GameWait", gameMsg);
            }
        }

        public void GameMove(MoveMessage msg)
        {
            Console.Write(msg);
        }
    }
}
