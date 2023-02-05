using Xiangqi.Game;

namespace Xiangqi.Web.Models.Messages
{
    public class PieceMessage
    {
        public string Piece { get; set; }
        public string Color { get; set; }
        public Position Position { get; set; }
        public IEnumerable<Position> Moves { get; set; }
    }

    public class GameMessage
    {
        public string GameId { get; set; }
        public string Turn { get; set; }
        public string Player { get; set; }
        public IEnumerable<PieceMessage> Board { get; set; }

        public static GameMessage Of(Game game) 
        {
            var gameId = game.GameId;
            var turn = game.ChessGame.Turn;

            var board = game.ChessGame.Board
                .GetPiecesWhere(p => p != null)
                .Select(
                    p => 
                    {
                        var moves = game.ChessGame.Board.AvailableMovesFrom(
                            new Position(p.Key.Row, p.Key.Col)
                        );

                        var pcMsg = new PieceMessage()
                        {
                            Piece = p.Value.PieceName(),
                            Color = p.Value.Color.ToString(),
                            Position = p.Key,
                            Moves = moves
                        };
                        return pcMsg;
                    }
                );

            var gameMsg = new GameMessage()
            {
                GameId = gameId.ToString(),
                Turn = turn.ToString(),
                Board = board
            };
            return gameMsg;
        }
    }
}
