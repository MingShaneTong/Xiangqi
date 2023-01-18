using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game
{
    public record File (Color Color, int FileCol)
    {
        public int ToColumn()
        { 
            if (Color == Color.Black) { return FileCol - 1; }
            return Board.Cols - FileCol;
        }
    }
}
