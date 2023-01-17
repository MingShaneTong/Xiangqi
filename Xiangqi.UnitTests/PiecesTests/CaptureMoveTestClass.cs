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
    public class CaptureMoveTestClass<TPiece> where TPiece : Piece, new()
    {
        public bool MoveIsValid(string color, int oldRow, int oldCol, int newRow, int newCol, string blockColor, int blockRow, int blockCol)
        {
            Enum.TryParse(color, out Color colorEnum);
            Enum.TryParse(blockColor, out Color blockColorEnum);

            Piece piece = new TPiece { Color = colorEnum };
            Piece blockPiece = Pawn.Of(blockColorEnum);

            Position oldPosition = new Position(oldRow, oldCol);
            Position newPosition = new Position(newRow, newCol);
            Position blockPosition = new Position(blockRow, blockCol);

            Board board = BoardCreator.BuildBoard(new Dictionary<Position, IPiece>
            {
                { oldPosition, piece },
                { blockPosition, blockPiece }
            });

            IMove move = new CaptureMove()
            {
                Color = colorEnum,
                OldPosition = oldPosition,
                NewPosition = newPosition,
                Piece = piece,
                PieceCaptured = blockPiece
            };
            return move.IsValid(board);
        }
    }
}
