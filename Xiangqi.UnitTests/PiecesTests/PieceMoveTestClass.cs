using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Pieces;
using Xiangqi.Game;

namespace Xiangqi.UnitTests.PiecesTests
{
    public class PieceMoveTestClass<TPiece> where TPiece : Piece, new()
    {
        public bool MoveIsValid(string color, int oldRow, int oldCol, int newRow, int newCol)
        {
            Enum.TryParse(color, out Color colorEnum);
            Piece piece = new TPiece { Color = colorEnum };
            Position oldPosition = new Position(oldRow, oldCol);
            Position newPosition = new Position(newRow, newCol);

            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { oldPosition, piece }
            });

            IMove move = new PieceMove()
            {
                OldPosition = oldPosition,
                NewPosition = newPosition,
                Piece = piece
            };
            return move.IsValid(board);
        }
    }
}
