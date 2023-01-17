using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class Pawn : Piece
    {
        private bool IsValidVerticalMove(Board board, Position oldPosition, Position newPosition)
        {
            // check same columns
            if (oldPosition.Col != newPosition.Col)
            {
                return false;
            }

            // red only moves up the board
            if (Color == Color.Red && newPosition.Row != oldPosition.Row - 1)
            {
                return false;
            }
            // black only moves down the board
            if (Color == Color.Black && newPosition.Row != oldPosition.Row + 1)
            {
                return false;
            }
            return true;
        }

        private bool IsValidHorizontalMove(Board board, Position oldPosition, Position newPosition)
        {
            // check same row
            if (oldPosition.Row != newPosition.Row)
            {
                return false;
            }

            // must move only 1 space
            if (Math.Abs(newPosition.Col - oldPosition.Col) != 1)
            {
                return false;
            }

            // cannot move horizontally if not on opponent side
            if (Color == Color.Red && Board.GetPositionSide(oldPosition) == Color.Red)
            {
                return false;
            }
            if (Color == Color.Black && Board.GetPositionSide(oldPosition) == Color.Black)
            {
                return false;
            }

            return true;
        }

        public override bool IsValidMove(Board board, Position oldPosition, Position newPosition, IPiece? pieceCaptured = null)
        {
            if (IsValidVerticalMove(board, oldPosition, newPosition)) { return true; }
            if (IsValidHorizontalMove(board, oldPosition, newPosition)) { return true; }
            return false;
        }

        public override string ToString()
        {
            switch (Color)
            {
                case Color.Black:
                    return "卒";
                case Color.Red:
                    return "兵";
                default:
                    throw new ArgumentException("The Piece Color is not valid");
            }
        }

        public static Pawn Of(Color color)
        {
            return new Pawn() { Color = color };
        }
    }
}
