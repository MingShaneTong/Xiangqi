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
    public class MoveTestClass<TPiece> where TPiece : Piece, new()
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

            IMove move = new Move()
            {
                Color = colorEnum,
                OldPosition = oldPosition,
                NewPosition = newPosition,
                Piece = piece
            };
            return move.IsValid(board);
        }

        public bool MoveIsValid(string color, int oldRow, int oldCol, int newRow, int newCol, int blockRow, int blockCol)
        {
            Enum.TryParse(color, out Color colorEnum);
            Piece piece = new TPiece { Color = colorEnum };
            Position oldPosition = new Position(oldRow, oldCol);
            Position newPosition = new Position(newRow, newCol);
            Position blockPosition = new Position(blockRow, blockCol);

            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { oldPosition, piece },
                { blockPosition, Pawn.Of(Color.Black) }
            });

            IMove move = new Move()
            {
                OldPosition = oldPosition,
                NewPosition = newPosition,
                Piece = piece
            };
            return move.IsValid(board);
        }
    }
}
