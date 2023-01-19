using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiangqi.Game.Pieces;

namespace Xiangqi.Game
{
    public class BoardCreator
    {
        public static Board Blank()
        {
            Board board = new Board()
            {
                Pieces = new IPiece[Board.Rows, Board.Cols]
            };
            return board;
        }

        public static Board InitBoard()
        {
            return BuildBoard(new Dictionary<Position, IPiece>()
            {
                { new Position(0, 0), Chariot.Of(Color.Black) },
                { new Position(0, 1), Horse.Of(Color.Black) },
                { new Position(0, 2), Elephant.Of(Color.Black) },
                { new Position(0, 3), Advisor.Of(Color.Black) },
                { new Position(0, 4), King.Of(Color.Black) },
                { new Position(0, 5), Advisor.Of(Color.Black) },
                { new Position(0, 6), Elephant.Of(Color.Black) },
                { new Position(0, 7), Horse.Of(Color.Black) },
                { new Position(0, 8), Chariot.Of(Color.Black) },

                { new Position(2, 1), Cannon.Of(Color.Black) },
                { new Position(2, 7), Cannon.Of(Color.Black) },

                { new Position(3, 0), Pawn.Of(Color.Black) },
                { new Position(3, 2), Pawn.Of(Color.Black) },
                { new Position(3, 4), Pawn.Of(Color.Black) },
                { new Position(3, 6), Pawn.Of(Color.Black) },
                { new Position(3, 8), Pawn.Of(Color.Black) },

                { new Position(6, 0), Pawn.Of(Color.Red) },
                { new Position(6, 2), Pawn.Of(Color.Red) },
                { new Position(6, 4), Pawn.Of(Color.Red) },
                { new Position(6, 6), Pawn.Of(Color.Red) },
                { new Position(6, 8), Pawn.Of(Color.Red) },

                { new Position(7, 1), Cannon.Of(Color.Red) },
                { new Position(7, 7), Cannon.Of(Color.Red) },

                { new Position(9, 0), Chariot.Of(Color.Red) },
                { new Position(9, 1), Horse.Of(Color.Red) },
                { new Position(9, 2), Elephant.Of(Color.Red) },
                { new Position(9, 3), Advisor.Of(Color.Red) },
                { new Position(9, 4), King.Of(Color.Red) },
                { new Position(9, 5), Advisor.Of(Color.Red) },
                { new Position(9, 6), Elephant.Of(Color.Red) },
                { new Position(9, 7), Horse.Of(Color.Red) },
                { new Position(9, 8), Chariot.Of(Color.Red) }
            });
        }

        public static Board BuildBoard(IDictionary<Position, IPiece> piecePlacements)
        {
            Board board = Blank();
            foreach ((Position pos, IPiece piece) in piecePlacements) 
            {
                board.SetPieceOn(pos, piece);
            }
            return board;
        }
    }
}
