﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class Advisor : Piece
    {
        public override bool IsValidMove(Board board, Position oldPosition, Position newPosition)
        {
            if (!Board.InCastle(Color, newPosition) || !Board.InCastle(Color, newPosition)) { return false; }
            return 
                Math.Abs(newPosition.Col - oldPosition.Col) == 1 && 
                Math.Abs(newPosition.Row - oldPosition.Row) == 1;
        }

        public override bool IsValidMove(Board board, Position oldPosition, Position newPosition, IPiece pieceCaptured)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            switch (Color) 
            {
                case Color.Black:
                    return "士";
                case Color.Red:
                    return "仕";
                default:
                    throw new ArgumentException("The Piece Color is not valid");
            }
        }

        public static Advisor Of(Color color)
        {
            return new Advisor() { Color = color };
        }
    }
}
