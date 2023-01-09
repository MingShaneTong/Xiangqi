﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Pieces
{
    public class Cannon : Piece, IPiece
    {
        public override string ToString()
        {
            switch (Color)
            {
                case Color.Black:
                    return "砲";
                case Color.Red:
                    return "炮";
                default:
                    throw new ArgumentException("The Piece Color is not valid");
            }
        }

        public static Cannon Of(Color color)
        {
            return new Cannon() { Color = color };
        }
    }
}