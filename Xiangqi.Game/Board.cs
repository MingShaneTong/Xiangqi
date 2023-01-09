using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Pieces;

namespace Xiangqi.Game
{
    public class Board
    {
        public IPiece[,] Pieces;

        public Board() 
        { 
            Pieces = new IPiece[10,9];
            Pieces[0, 0] = Chariot.Of(Color.Black);
            Pieces[0, 1] = Horse.Of(Color.Black);
            Pieces[0, 2] = Elephant.Of(Color.Black);
            Pieces[0, 3] = Advisor.Of(Color.Black);
            Pieces[0, 4] = General.Of(Color.Black);
            Pieces[0, 5] = Advisor.Of(Color.Black);
            Pieces[0, 6] = Elephant.Of(Color.Black);
            Pieces[0, 7] = Horse.Of(Color.Black);
            Pieces[0, 8] = Chariot.Of(Color.Black);

            Pieces[2, 1] = Cannon.Of(Color.Black);
            Pieces[2, 7] = Cannon.Of(Color.Black);

            Pieces[3, 0] = Soldier.Of(Color.Black);
            Pieces[3, 2] = Soldier.Of(Color.Black);
            Pieces[3, 4] = Soldier.Of(Color.Black);
            Pieces[3, 6] = Soldier.Of(Color.Black);
            Pieces[3, 8] = Soldier.Of(Color.Black);

            Pieces[6, 0] = Soldier.Of(Color.Red);
            Pieces[6, 2] = Soldier.Of(Color.Red);
            Pieces[6, 4] = Soldier.Of(Color.Red);
            Pieces[6, 6] = Soldier.Of(Color.Red);
            Pieces[6, 8] = Soldier.Of(Color.Red);

            Pieces[7, 1] = Cannon.Of(Color.Red);
            Pieces[7, 7] = Cannon.Of(Color.Red);

            Pieces[9, 0] = Chariot.Of(Color.Red);
            Pieces[9, 1] = Horse.Of(Color.Red);
            Pieces[9, 2] = Elephant.Of(Color.Red);
            Pieces[9, 3] = Advisor.Of(Color.Red);
            Pieces[9, 4] = General.Of(Color.Red);
            Pieces[9, 5] = Advisor.Of(Color.Red);
            Pieces[9, 6] = Elephant.Of(Color.Red);
            Pieces[9, 7] = Horse.Of(Color.Red);
            Pieces[9, 8] = Chariot.Of(Color.Red);
        }

        public override string ToString()
        {
            int row = Pieces.GetUpperBound(0) + 1;
            int col = Pieces.GetUpperBound(1) + 1;

            string[] rowString = new string[row];
            for (int i = 0; i < row; i++)
            {
                string[] colString = new string[col];
                for (int j = 0; j < col; j++)
                {
                    IPiece p = Pieces[i,j];
                    colString[j] = p != null ? p.ToString() : "。";
                }
                rowString[i] = string.Join("|", colString);
            }
            return string.Join("\n", rowString);
        }
    }
}
