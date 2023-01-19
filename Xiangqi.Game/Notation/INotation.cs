using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;

namespace Xiangqi.Game.Notation
{
    public interface INotation
    {
        public Move ToMove(Board board, Color color, string notation);
    }
}
