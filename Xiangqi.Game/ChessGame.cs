using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;

namespace Xiangqi.Game
{
    public class ChessGame
    {
        public Board Board { get; init; }
        public Color Turn { get; private set; }
        public IList<Move> Moves { get; init; }

        public ChessGame() 
        {
            Board = BoardCreator.InitBoard();
            Moves = new List<Move>();
            Turn = Color.Red;
        }

        public void PerformTurn(Move move)
        {
            if (move.Color != Turn) { throw new Exception("Wrong Player Turn"); }
            move.Apply(Board);
            Turn = Turn == Color.Red ? Color.Black : Color.Red;
        }
    }
}
