﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Moves;
using Xiangqi.Game.Notation;

namespace Xiangqi.Game
{
    public class ChessGame
    {
        public Board Board { get; init; }
        public Color Turn { get; private set; }
        public INotation Notation { get; private set; }
        public IList<Round> Rounds { get; init; }
        private Round CurrentRound { get; set; }

        public ChessGame() 
        {
            Board = BoardCreator.InitBoard();
            Rounds = new List<Round>();
            Turn = Color.Red;
            Notation = new BasicAlgebraicNotation();
            CurrentRound = new Round();
        }
        
        public void PerformTurn(string notation)
        {
            Move move = Notation.ToMove(Board, Turn, notation);
            if (move.Color != Turn) { throw new Exception("Wrong Player Turn"); }
            move.Apply(Board);
            if (Turn == Color.Red)
            {
                Turn = Color.Black;
                CurrentRound.RedMove = move;
                Rounds.Add(CurrentRound);
            }
            else
            {
                Turn = Color.Red;
                CurrentRound.BlackMove = move;
                CurrentRound = new Round();
            }
        }
    }
}
