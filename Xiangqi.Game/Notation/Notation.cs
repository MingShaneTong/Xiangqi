using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;

namespace Xiangqi.Game.Notation
{
    public abstract class Notation : INotation
    {
        public abstract Move ToMove(Board board, Color color, string notation);
    }
}
