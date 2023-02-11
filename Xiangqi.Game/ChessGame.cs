using Xiangqi.Game.Moves;
using Xiangqi.Game.Notation;

namespace Xiangqi.Game
{
    public class ChessGame
    {
        public Board Board { get; init; }
        public Color Turn { get; private set; }
        public INotation Notation { get; private set; }
        public IList<Round> Rounds { get; init; }
        private Round CurrentRound { get; set; }

        public ChessGame() 
        {
            Board = BoardCreator.InitBoard();
            Rounds = new List<Round>();
            Turn = Color.Red;
            Notation = new RowColNotation();
            CurrentRound = new Round();
        }

        public ChessGame(INotation notation)
        {
            Board = BoardCreator.InitBoard();
            Rounds = new List<Round>();
            Turn = Color.Red;
            Notation = notation;
            CurrentRound = new Round();
        }

        public GameStatus GetStatus()
        {
            if (Board.IsInCheckmate(Turn)) 
            { 
                return GameStatus.Checkmate;
            }
            if (Board.IsInStalemate(Turn))
            {
                return GameStatus.Stalemate;
            }
            if(Board.KingInCheck(Turn))
            {
                return GameStatus.Check;
            }
            return GameStatus.InProgress;
        }

        public void PerformTurn(string notation)
        {
            var move = Notation.ToMove(Board, Turn, notation);
            PerformTurn(move);
        }

        public void PerformTurn(Move move)
        { 
            if (move.Color != Turn) { throw new Exception("Wrong Player Turn"); }
            move.Apply(Board);
            if (Turn == Color.Red)
            {
                Turn = Color.Black;
                CurrentRound.RedMove = move;
                Rounds.Add(CurrentRound);
            }
            else
            {
                Turn = Color.Red;
                CurrentRound.BlackMove = move;
                CurrentRound = new Round();
            }
        }
    }
}
