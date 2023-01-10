using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiangqi.Game.Moves
{
    public interface IMove
    {
        public bool IsValid(Board board);
        public void Apply(Board board);
    }
}
