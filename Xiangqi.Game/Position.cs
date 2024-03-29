﻿namespace Xiangqi.Game
{
    public record Position(int Row, int Col)
    {
        public bool IsValid()
        {
            if (Row < 0 || Row >= Board.Rows) { return false; }
            if (Col < 0 || Col >= Board.Cols) { return false; }
            return true;
        }
    }

}
