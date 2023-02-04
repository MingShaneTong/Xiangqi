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
            var board = new Board()
            {
                Pieces = new IPiece[Board.Rows, Board.Cols]
            };
            return board;
        }

        public static Board InitBoard()
        {
            return BuildBoard(new Dictionary<Position, IPiece>()
            {
                { new Position(0, 0), Rook.Of(Color.Black) },
                { new Position(0, 1), Horse.Of(Color.Black) },
                { new Position(0, 2), Elephant.Of(Color.Black) },
                { new Position(0, 3), Advisor.Of(Color.Black) },
                { new Position(0, 4), King.Of(Color.Black) },
                { new Position(0, 5), Advisor.Of(Color.Black) },
                { new Position(0, 6), Elephant.Of(Color.Black) },
                { new Position(0, 7), Horse.Of(Color.Black) },
                { new Position(0, 8), Rook.Of(Color.Black) },

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

                { new Position(9, 0), Rook.Of(Color.Red) },
                { new Position(9, 1), Horse.Of(Color.Red) },
                { new Position(9, 2), Elephant.Of(Color.Red) },
                { new Position(9, 3), Advisor.Of(Color.Red) },
                { new Position(9, 4), King.Of(Color.Red) },
                { new Position(9, 5), Advisor.Of(Color.Red) },
                { new Position(9, 6), Elephant.Of(Color.Red) },
                { new Position(9, 7), Horse.Of(Color.Red) },
                { new Position(9, 8), Rook.Of(Color.Red) }
            });
        }

        public static Board BuildBoard(IDictionary<Position, IPiece> piecePlacements)
        {
            var board = Blank();
            foreach ((var pos, var piece) in piecePlacements) 
            {
                board.SetPieceOn(pos, piece);
            }
            return board;
        }

        public static Board BuildBoard(string boardString)
        {
            var board = Blank();

            var rows = boardString.Split("\n");
            for (int i = 0; i < rows.Length; i++)
            {
                var cols = rows[i].Split("|");
                for (var j = 0; j < cols.Length; j++)
                {
                    var pieceString = cols[j];
                    var piece = PieceParser.ToPiece(pieceString);
                    var position = new Position(i, j);
                    board.SetPieceOn(position, piece);
                }
            }
            return board;
        }
    }
}
