using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;
using Xiangqi.Game;
using Xiangqi.Game.Notation;

namespace Xiangqi.UnitTests
{
    public class TestSupport
    {
        public static bool MoveIsValid(string givenBoard, Color whenColor, string whenMove)
        {
            Notation notation = new BasicAlgebraicNotation();
            Board board = BoardCreator.BuildBoard(givenBoard);
            Move move = notation.ToMove(board, whenColor, whenMove);
            return move.IsValid(board);
        }
    }
}
